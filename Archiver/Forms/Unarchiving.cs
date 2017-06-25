using Archiver;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Archiver.Trees;

namespace Archiver.Forms
{
    public partial class Unarchiving : Form
    {
        #region fields
        private readonly int _stepForProgressbar = Convert.ToInt32(Properties.Resources.StepForProgressbar);
        private readonly int _timerInterval = Convert.ToInt32(Properties.Resources.TimerInterval);

        private string _fileFullName;
        private int _countOfNulls;
        private long _fileLength;

        private Tree _tree;

        private TimeSpan _timePassed;
        private TimeSpan _timeRemaining;
        private DateTime _timeStart;

        private readonly BackgroundWorker _backgroundWorkerUnarchive;

        private readonly AddProgress _addProgress;
        private readonly SetStatusLabelText _setStatusLabelText;
        #endregion

        public Unarchiving(string filePath)
        {
            this.InitializeComponent();

            if (!String.IsNullOrWhiteSpace(filePath))
            {
                this.txbxArhivePath.Text = filePath;
                this.txbxResultPath.Text = filePath.Remove(filePath.LastIndexOf(@"\") + 1);
            }

            this._backgroundWorkerUnarchive = new BackgroundWorker();
            this._backgroundWorkerUnarchive.WorkerSupportsCancellation = true;
            this._backgroundWorkerUnarchive.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._backgroundWorkerUnarchive_RunWorkerCompleted);
            this._backgroundWorkerUnarchive.DoWork += new DoWorkEventHandler(this._backgroundWorkerUnarchive_DoWork);

            this._addProgress = new AddProgress(this.AddProgressMethod);
            this._setStatusLabelText = new SetStatusLabelText(SetStatusLabelStatusMethod);

            this.progressBar1.Maximum = this._stepForProgressbar;
            this.timerProgress.Interval = this._timerInterval;
        }

        private void ConvertToTree(byte[] bytes)
        {
            List<bool> list = new List<bool>();

            foreach (byte b in bytes)
                list.AddRange(WorkWithBits.ByteToBinBoolean(b));

            for (int i = 0; i < this._countOfNulls; i++)
                list.RemoveAt(list.Count - 1);

            this._tree = new Tree(list.ToArray());
            this._tree.BuildHuffmanTable();
        }

        private void ParseBitFile()
        {
            using (BinaryReader reader = new BinaryReader(new FileStream(this.txbxArhivePath.Text, FileMode.Open)))
            {
                try
                {
                    // length file name
                    int lengthFileName = reader.ReadInt32();

                    // get extension
                    for (int i = 0; i < lengthFileName; i++)
                        this._fileFullName += reader.ReadChar();

                    // length file
                    this._fileLength = reader.ReadInt64();

                    // get length tree
                    short lengthBit = reader.ReadInt16();

                    // get length of null
                    this._countOfNulls = reader.ReadInt16();

                    // get tree
                    byte[] treeByte = new byte[(lengthBit / 8) + 1];
                    for (int i = 0; i < treeByte.Length; i++)
                        treeByte[i] = reader.ReadByte();

                    this.ConvertToTree(treeByte);

                    WriteFileIntoFile(reader);
                }
                catch (EndOfStreamException) { }
            }

        }
        private void WriteFileIntoFile(BinaryReader reader)
        {
            string[] filePathAndName = { this.txbxResultPath.Text, @"\", this._fileFullName };
            
            this._timeStart = DateTime.Now;

            using (BinaryWriter writer = new BinaryWriter(File.Open(string.Concat(filePathAndName),
                                                          FileMode.Create, FileAccess.ReadWrite, FileShare.Read)))
            {
                Branch currentBranch = this._tree.Root;

                long sizeOnePersentProgress = this._fileLength / this._stepForProgressbar;
                long counterProgress = 0;

                try
                {
                    while (true)
                    {
                        byte tempByte = reader.ReadByte();

                        for (int i = 7; i > -1; i--)
                        {
                            if (!currentBranch.isEmptyBranch)
                            {
                                writer.Write(currentBranch.Symbol);
                                currentBranch = this._tree.Root;

                                counterProgress++;

                                if (counterProgress == sizeOnePersentProgress)
                                {
                                    counterProgress = 0;
                                    ProgressBarAddedProgress();
                                }
                            }

                            if (Convert.ToBoolean(tempByte & (1 << i)))
                                currentBranch = currentBranch.Right;
                            else
                                currentBranch = currentBranch.Left;
                        }
                    }
                }
                catch (EndOfStreamException) { }
            }
        }

        private void AddProgressMethod(int value)
        {
            if (this.progressBar1.Value < this.progressBar1.Maximum)
                this.progressBar1.Value += value;
        }
        private void SetStatusLabelStatusMethod(string text)
        {
            this.lblStatusWork.Text = text;
        }

        #region events
        private void btnChangeArchivePath_Click(object sender, EventArgs e)
        {
            this.txbxArhivePath.Text = WorkWithFile.OpenFile();

            if (!String.IsNullOrWhiteSpace(this.txbxArhivePath.Text))
                this.txbxResultPath.Text = this.txbxArhivePath.Text.Remove(this.txbxArhivePath.Text.LastIndexOf(@"\") + 1);
        }
        private void btnChangeResultPath_Click(object sender, EventArgs e)
        {
            this.txbxResultPath.Text = WorkWithFile.OpenFolder();
        }
        private void btnUnarchiving_Click(object sender, EventArgs e)
        {
            string[] fileName = this.txbxArhivePath.Text.Split('.');
            string fileExtension = fileName[fileName.Length - 1];

            if (this.progressBar1.Value == this.progressBar1.Maximum)
            {
                this.Dispose();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txbxArhivePath.Text) )
            {
                MessageBox.Show("Choose file filePath");
                this.btnChangeArchivePath_Click(null, null);
            }
            else if (fileExtension != "Haffman")
            {
                MessageBox.Show("Choose correct file (.Huffman)");
                this.btnChangeArchivePath_Click(null, null);
            }
            else if (string.IsNullOrWhiteSpace(this.txbxResultPath.Text))
            {
                MessageBox.Show("Choose arhive filePath");
                this.btnChangeResultPath_Click(null, null);
            }
            else
            {
                this.timerProgress.Start();

                this._backgroundWorkerUnarchive.RunWorkerAsync();
            }
        }
        private void Unarchiving_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._backgroundWorkerUnarchive.CancelAsync();
        }

        private void _backgroundWorkerUnarchive_DoWork(object sender, DoWorkEventArgs e)
        {
            Invoke(this._setStatusLabelText, "Unarchiving..");

            this.ParseBitFile();
        }
        private void _backgroundWorkerUnarchive_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!this._backgroundWorkerUnarchive.CancellationPending)
                Invoke(this._setStatusLabelText, "Completed");

            this.timerProgress.Stop();
            this.btnChangeArchivePath.Enabled = false;
            this.btnChangeFilePath.Enabled = false;

            this.btnUnarchiving.Text = "OK";
            this.lblTimerRemaining.Text = "--:--:--.---";
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            this._timePassed = DateTime.Now - this._timeStart;

            string temp = this._timePassed.ToString();
            this.lblTimerPassed.Text = temp.Remove(temp.Length - 4);
            
            if (this.progressBar1.Value > 1)
            {
                string tempRemaining = this._timeRemaining.ToString();
                this.lblTimerRemaining.Text = tempRemaining.Remove(tempRemaining.Length - 4);
            }
        }

        private void ProgressBarAddedProgress()
        {
            try { Invoke(this._addProgress, 1); }
            catch (ObjectDisposedException) { Application.Exit(); }
            catch (InvalidOperationException) { Application.Exit(); }

            this._timePassed = DateTime.Now - this._timeStart;

            double secondsRemaining = (this._timePassed.TotalSeconds / this.progressBar1.Value) *
                                      (this._stepForProgressbar - this.progressBar1.Value);
            this._timeRemaining = TimeSpan.FromSeconds(secondsRemaining);
        }
        #endregion

        private delegate void AddProgress(int value);
        private delegate void SetStatusLabelText(string text);
    }
}
