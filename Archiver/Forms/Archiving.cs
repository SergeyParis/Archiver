
using Archiver.Trees;

namespace Archiver.Forms
{
    using Archiver;
    using Archiver.Trees;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Forms;

    public partial class Archiving : Form
    {
        #region fields
        private readonly int _stepForProgressbar = Convert.ToInt32(Properties.Resources.StepForProgressbar);
        private readonly int _timerInterval = Convert.ToInt32(Properties.Resources.TimerInterval);

        private int _countOfNulls;
        private long _fileLength;

        private int[] _byteDictionary;
        private Tree _tree;

        private BinaryWriter _writer;
        private BinaryReader _reader;
        private FileStream _streamRead;

        private TimeSpan _timePassed;
        private TimeSpan _timePassedOnlyFile;
        private TimeSpan _timeRemaining;
        private DateTime _timeStart;
        private DateTime _timeStartOnlyFile;

        private readonly BackgroundWorker _backgroundWorkerArchive;

        private readonly AddProgress _addProgressMain;
        private readonly AddProgress _addProgressInfo;
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

            this._addProgressMain = new AddProgress(this.AddProgressBarMainValue);
            this._addProgressInfo = new AddProgress(this.AddProgressBarInfoValue);

            this._backgroundWorkerArchive.WorkerSupportsCancellation = true;
            this._backgroundWorkerArchive.DoWork += new DoWorkEventHandler(this.BackgroundWorkerArchive_DoWork);
            this._backgroundWorkerArchive.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackgroundWorkerArchive_RunWorkerCompleted);

            WorkWithFile.FillDictionaryReportProgress += WorkWithFile_FillDictionaryReportProgress;

            this._setStatusLabelText = new SetStatusLabelText(SetStatusLabelStatusMethod);
        }

        private void CreateTree()
        {
            this._byteDictionary = WorkWithFile.FillDictionary(this.txbxFilePath.Text);

            this._tree = new Tree(this._byteDictionary);
            this._tree.BuildBinnaryCode();
            this._tree.BuildHuffmanTable();
        }

        private void WriteFile()
        {
            this._fileLength = new FileInfo(this.txbxFilePath.Text).Length;

            using (_writer = new BinaryWriter(File.Open(
                this.txbxArchivePath.Text + @"\" + this.txbxArchiveName.Text + ".Haffman", FileMode.Create,
                FileAccess.ReadWrite, FileShare.Read)))
            {


                this.WritePreInfo();
                this.WriteFileIntoFile(this.txbxFilePath.Text);
            }
        }
        private void WriteTree(bool[] bools)
        {
            string bits = string.Empty;

            for (int i = 0; i < bools.Length; i++)
                bits += Convert.ToInt32(bools[i]);

            while (bits.Length >= 8)
            {
                _writer.Write(Convert.ToByte(bits.Substring(0, 8), 2));
                bits = bits.Remove(0, 8);
            }

            for (int i = 0; 8 != bits.Length; i++)
                bits += "0";

            _writer.Write(Convert.ToByte(bits.Substring(0, 8), 2));
        }
        private void WritePreInfo()
        {
            // length name file
            _writer.Write(WorkWithFile.OpenFile_FullFileName.Length);

            // name file
            _writer.Write(WorkWithFile.OpenFile_FullFileName.ToCharArray());

            // length file
            _writer.Write(this._fileLength);

            // length of tree
            _writer.Write((short)this._tree.BinnaryCode.Count);

            // length null byte tree
            this._countOfNulls = 8 - (_tree.BinnaryCode.Length % 8);
            _writer.Write((short)this._countOfNulls);

            // tree
            bool[] bools = new bool[this._tree.BinnaryCode.Length];
            for (int i = 0; i < this._tree.BinnaryCode.Length; i++)
                bools[i] = this._tree.BinnaryCode[i];

            this.WriteTree(bools);
        }
        private void WriteFileIntoFile(string filePath)
        {
            long sizeOneProgress = this._fileLength / _stepForProgressbar;
            this._timeStartOnlyFile = DateTime.Now;

            using (_streamRead = new FileStream(filePath, FileMode.Open))
            {
                _reader = new BinaryReader(_streamRead);

                int tempByte = 0;
                int counterBits = 0;
                long counterProgress = 0;

                try
                {
                    while (true)
                    {
                        foreach (int code in this._tree.HuffmanTable[_reader.ReadByte()])
                        {
                            tempByte |= code << (7 - counterBits++);

                            // write byte
                            if (counterBits == 8)
                            {
                                counterProgress++;

                                _writer.Write(Convert.ToByte(tempByte));

                                tempByte >>= 8; // tempByte = 0;
                                counterBits >>= 4; // counter = 0;

                                // report progress
                                if (counterProgress == sizeOneProgress)
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
                        _writer.Write(Convert.ToByte(tempByte));
                }
                finally { _reader.Close(); }
            }

        }

        private void AddProgressBarMainValue(int value)
        {
            if (this.progressBarFileArchiving.Value < this.progressBarFileArchiving.Maximum)
                this.progressBarFileArchiving.Value += value;
        }
        private void AddProgressBarInfoValue(int value)
        {
            this.progressBarInfoArchiving.Value += value;
        }
        private void SetStatusLabelStatusMethod(string text)
        {
            this.lblStatusWork.Text = text;
        }

        #region events
        private void btnArchiving_Click(object sender, EventArgs e)
        {
            if (this.progressBarInfoArchiving.Value == this.progressBarInfoArchiving.Maximum)
            {
                this.Dispose();
                return;
            }

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
                this.progressBarFileArchiving.Maximum = _stepForProgressbar;

                this._timeStart = DateTime.Now;

                this.timerProgress.Interval = _timerInterval;
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

            if (!String.IsNullOrWhiteSpace(this.txbxFilePath.Text))
                this.txbxArchivePath.Text = this.txbxFilePath.Text.Remove(this.txbxFilePath.Text.LastIndexOf(@"\") + 1);
        }
        private void Archiving_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._backgroundWorkerArchive.CancelAsync();
        }

        private void ProgressBarAddedProgress()
        {
            try { Invoke(this._addProgressMain, 1); }
            catch (ObjectDisposedException) { return; }
            catch { }

            this._timePassedOnlyFile = DateTime.Now - this._timeStartOnlyFile;

            double secondsRemaining = (this._timePassedOnlyFile.TotalSeconds / this.progressBarFileArchiving.Value) *
                                      (this._stepForProgressbar - this.progressBarFileArchiving.Value);
            this._timeRemaining = TimeSpan.FromSeconds(secondsRemaining);
        }
        private void WorkWithFile_FillDictionaryReportProgress()
        {
            try { Invoke(_addProgressInfo, 1); }
            catch (ObjectDisposedException) { Application.Exit(); }
            catch (InvalidOperationException) { Application.Exit(); }
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            this._timePassed = DateTime.Now - this._timeStart;

            string temp = _timePassed.ToString();
            this.lblTimerPassed.Text = temp.Remove(temp.Length - 4);

            if (this.progressBarFileArchiving.Value > 2)
            {
                string tempRemaining = this._timeRemaining.ToString();
                this.lblTimerRemaining.Text = tempRemaining.Remove(tempRemaining.Length - 4);
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

            this.timerProgress.Stop();
            this.btnChangeArchivePath.Enabled = false;
            this.btnChangeFilePath.Enabled = false;

            this.btnArchiving.Text = "OK";
            this.lblTimerRemaining.Text = "--:--:--.---";
        }
        #endregion

        private delegate void AddProgress(int value);
        private delegate void SetStatusLabelText(string text);
    }
}
