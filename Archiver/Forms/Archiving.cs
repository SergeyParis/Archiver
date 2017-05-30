using System.Text;

namespace Lab_2.Forms
{
    using Lab_2;
    using Lab_2.Trees;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;

    public partial class Archiving : Form
    {
        private const int STEP_FOR_PROGRESSBAR = 1000;

        #region fields
        private byte[] _allSymbols;
        private int _countOfNulls;
        private long _fileLength;

        private int[] _byteDictionary;
        private Tree _tree;

        private DateTime _timeStartArchiving;
        private TimeSpan _timeRemaningArchiving;

        private readonly BackgroundWorker _backgroundWorkerArchive;

        private readonly AddProgress _addProgress;
        private readonly SetMaximalProgressBarValueDelegate _setMaximalProgressBarValueDelegate;
        private readonly SetStatusLabelText _setStatusLabelText;
        #endregion

        public Archiving(string filePath)
        {
            this.InitializeComponent();

            if (!String.IsNullOrWhiteSpace(filePath))
            {
                this.txbxFilePath.Text = filePath;
                this.txbxArchivePath.Text = filePath.Remove(filePath.LastIndexOf(@"\") + 1);
            }

            this._backgroundWorkerArchive = new BackgroundWorker();

            this._setMaximalProgressBarValueDelegate = new SetMaximalProgressBarValueDelegate(this.SetMaximalProgressBarValue);
            this._addProgress = new AddProgress(this.AddProgressBarValue);

            this._backgroundWorkerArchive.WorkerSupportsCancellation = true;
            this._backgroundWorkerArchive.DoWork += new DoWorkEventHandler(this.BackgroundWorkerArchive_DoWork);
            this._backgroundWorkerArchive.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorkerArchive_RunWorkerCompleted);

            this._setStatusLabelText = new SetStatusLabelText(SetStatusLabelStatusMethod);
        }

        private void CreateTree()
        {
            this._allSymbols = WorkWithFile.ReadAllBytes(this.txbxFilePath.Text);
            this._byteDictionary = WorkWithBytes.FillDictionary(this._allSymbols);

            this._tree = new Tree(this._byteDictionary);
            this._tree.BuildBinnaryCode();
            this._tree.BuildHuffmanTable();
        }

        private void WriteFile()
        {
            this._fileLength = new FileInfo(this.txbxFilePath.Text).Length;

            using (BinaryWriter writer = new BinaryWriter(File.Open(this.txbxArchivePath.Text + @"\" + this.txbxArchiveName.Text + ".Haffman", FileMode.Create, FileAccess.ReadWrite, FileShare.Read)))
            {
                this.WritePreInfo(writer);
                this.WriteFileIntoFile(writer, this.txbxFilePath.Text);
            }
        }
        private void WriteTree(BinaryWriter writer, bool[] bools)
        {
            string bits = string.Empty;
            string lastbit = string.Empty;

            for (int i = 0; i < bools.Length; i++)
                bits += Convert.ToInt32(bools[i]);

            while (bits.Length >= 8)
            {
                writer.Write(Convert.ToByte(bits.Substring(0, 8), 2));
                bits = bits.Remove(0, 8);
            }

            for (int i = 0; 8 != bits.Length; i++)
                bits += "0";

            writer.Write(Convert.ToByte(bits.Substring(0, 8), 2));
        }
        private void WritePreInfo(BinaryWriter writer)
        {
            // length name file
            writer.Write(WorkWithFile.OpenFile_FullFileName.Length);

            // name file
            writer.Write(WorkWithFile.OpenFile_FullFileName.ToCharArray());

            // length file
            writer.Write(this._fileLength);

            // length of tree
            writer.Write((short)this._tree.BinnaryCode.Count);

            // length null byte tree
            this._countOfNulls = 8 - (_tree.BinnaryCode.Length % 8);
            writer.Write((short)this._countOfNulls);

            // tree
            bool[] bools = new bool[this._tree.BinnaryCode.Length];
            for (int i = 0; i < this._tree.BinnaryCode.Length; i++)
                bools[i] = this._tree.BinnaryCode[i];

            this.WriteTree(writer, bools);
        }
        private void WriteFileIntoFile(BinaryWriter writer, string filePath)
        {
            long sizeOnePersentProgress = this._fileLength / 100;

            using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
            {
                int tempByte = 0;
                int counterBits = 0;
                long counterProgress = 0;

                try
                {
                    while (true)
                    {
                        foreach (int code in this._tree.HuffmanTable[reader.ReadByte()])
                        {
                            tempByte |= code << (7 - counterBits++);

                            // write byte
                            if (counterBits == 8)
                            {
                                counterProgress++;

                                writer.Write(Convert.ToByte(tempByte));

                                tempByte >>= 8; // tempByte = 0;
                                counterBits >>= 4; // counter = 0;

                                // report progress
                                if (counterProgress == sizeOnePersentProgress)
                                {
                                    counterProgress = 0;
                                    ProgressBarAddedProgress();
                                }
                            }
                        }
                    }
                }
                catch (EndOfStreamException)
                {
                    if (counterBits != 0) // add last byte
                        writer.Write(Convert.ToByte(tempByte));
                }
            }

        }

        private void AddProgressBarValue(int value)
        {
            this.progressBar1.Value += value;
        }
        private void SetMaximalProgressBarValue(long max)
        {
            this.progressBar1.Value = 0;
            this.progressBar1.Minimum = 0;

            int temp = (int)(max / STEP_FOR_PROGRESSBAR);
            this.progressBar1.Maximum = temp;
        }
        private void SetStatusLabelStatusMethod(string text)
        {
            this.lblStatusWork.Text = text;
        }

        #region events
        private void btnArchiving_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txbxFilePath.Text))
            {
                MessageBox.Show("Choose file path");
                this.btnChangeFilePath_Click(null, null);
            }
            else if (string.IsNullOrWhiteSpace(this.txbxArchivePath.Text))
            {
                MessageBox.Show("Choose arhive path");
                this.btnChangeArchivePath_Click(null, null);
            }
            else
            {
                this._timeStartArchiving = DateTime.Now;

                this.timerProgress.Interval = 100;
                this.timerProgress.Start();

                this._backgroundWorkerArchive.RunWorkerAsync();
            }
        }
        private void btnChangeArchivePath_Click(object sender, EventArgs e)
        {
            this.txbxArchivePath.Text = WorkWithFile.OpenFolder();
        }
        private void btnChangeFilePath_Click(object sender, EventArgs e)
        {
            this.txbxFilePath.Text = WorkWithFile.OpenFile();
            this.txbxArchivePath.Text = this.txbxFilePath.Text.Remove(this.txbxFilePath.Text.LastIndexOf(@"\") + 1);
        }
        private void Archiving_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._backgroundWorkerArchive.CancelAsync();
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            TimeSpan passedTime = DateTime.Now - this._timeStartArchiving;

            string temp = passedTime.ToString();
            this.lblTimer.Text = temp.Remove(temp.Length - 4);

            if (this.progressBar1.Value > 2)
            {
                string tempRemaining = (this._timeRemaningArchiving - passedTime).ToString();
                this.lblTimerRemaining.Text = tempRemaining.Remove(tempRemaining.Length - 4);
            }
        }
        TimeSpan _onePersent;
        TimeSpan _secondPersent;
        private void ProgressBarAddedProgress()
        {
            try { Invoke(this._addProgress, 1); }
            catch (ObjectDisposedException) { return; }

            if (this.progressBar1.Value == 1)
                _onePersent = DateTime.Now - this._timeStartArchiving;

            if (this.progressBar1.Value == 2)
            {
                TimeSpan temp = DateTime.Now - this._timeStartArchiving;

                _secondPersent = temp - _onePersent;
                this._timeRemaningArchiving = TimeSpan.FromSeconds(_secondPersent.TotalSeconds * 100);
            }
        }

        private void BackgroundWorkerArchive_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(this._setStatusLabelText, "Archiving..");

            this.CreateTree();
            this.WriteFile();
        }
        private void BackgroundWorkerArchive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this._backgroundWorkerArchive.CancellationPending)
                Invoke(this._setStatusLabelText, "Completed");
        }
        #endregion

        private delegate void AddProgress(int value);
        private delegate void SetMaximalProgressBarValueDelegate(long max);
        private delegate void SetStatusLabelText(string text);
    }
}
