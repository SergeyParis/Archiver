namespace Lab_2
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public static class WorkWithFile
    {
        public static string OpenFile_FileExtension = string.Empty;
        public static string OpenFile_FullFileName = string.Empty;
        
        public static string OpenFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                char[] separator = new char[] { '.' };

                string[] extension = dialog.SafeFileName.Split(separator);
                OpenFile_FileExtension = extension[extension.Length - 1];

                OpenFile_FullFileName = dialog.SafeFileName;

                return dialog.FileName;
            }
            return string.Empty;
        }
        public static string OpenFolder()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return string.Empty;
        }

        public static byte[] ReadAllBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }
        public static int[] FillDictionary(string filePath)
        {
            int counter = 0;
            long onePersent = new FileInfo(filePath).Length / 100;

            int[] dictionary = new int[256];


            using (FileStream stream = new FileStream(filePath, FileMode.Open))
            {
                BinaryReader reader = new BinaryReader(stream);

                try
                {
                    while (true)
                    {
                        dictionary[reader.ReadByte()]++;
                        
                        counter++;

                        if (counter == onePersent)
                        {
                            FillDictionaryReportProgress?.Invoke();
                            counter = 0;
                        }
                        
                    }
                }
                catch (EndOfStreamException) { }
            }

            return dictionary;
        }

        public delegate void FillDictionaryReportProgressDelegate();
        public static event FillDictionaryReportProgressDelegate FillDictionaryReportProgress;
    }
}
