namespace Lab_2
{
    using Lab_2.Trees;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public static class WorkWithBits
    {
        public static byte BooleanToBin(bool[] bools)
        {
            short num = 0;
            double y = bools.Length - 1;

            bool[] flagArray = bools;

            for (int i = 0; i < flagArray.Length; i++)
            {
                if (flagArray[i])
                {
                    num = (short)(num + ((short)Math.Pow(2.0, y)));
                    y--;
                }
                else
                {
                    y--;
                }
            }
            Convert.ToByte(num);
            return Convert.ToByte(num);
        }

        public static StringBuilder BooleanToStringBuilder(bool[] bools)
        {
            StringBuilder builder = new StringBuilder();
            bool[] flagArray = bools;
            for (int i = 0; i < flagArray.Length; i++)
            {
                if (flagArray[i])
                {
                    builder.Append('1');
                }
                else
                {
                    builder.Append('0');
                }
            }
            return builder;
        }

        public static bool[] ByteToBinBoolean(byte symbol)
        {
            return ByteToBinBoolean(symbol, 1);
        }
        public static bool[] ByteToBinBoolean(string symbolBits)
        {
            return ByteToBinBoolean(symbolBits, 1);
        }
        public static bool[] ByteToBinBoolean(byte symbol, int countByte)
        {
            return ByteToBinBoolean(Convert.ToString(symbol, 2), countByte);
        }
        public static bool[] ByteToBinBoolean(string symbolBits, int countByte)
        {
            int[] numArray = ByteToBinInt(symbolBits, countByte);
            bool[] flagArray = new bool[numArray.Length];
            for (int i = 0; i < numArray.Length; i++)
            {
                if (numArray[i] == 1)
                {
                    flagArray[i] = true;
                }
                else
                {
                    flagArray[i] = false;
                }
            }
            return flagArray;
        }
        public static bool[] ByteToBinBooleanNoPrefix(byte symbol)
        {
            string str = Convert.ToString(symbol, 2);
            bool[] flagArray = new bool[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0')
                {
                    flagArray[i] = false;
                }
                else
                {
                    flagArray[i] = true;
                }
            }
            return flagArray;
        }

        public static int[] ByteToBinInt(byte symbol)
        {
            return ByteToBinInt(symbol, 1);
        }
        public static int[] ByteToBinInt(string symbolBits)
        {
            return ByteToBinInt(symbolBits, 1);
        }
        public static int[] ByteToBinInt(byte symbol, int countByte)
        {
            return ByteToBinInt(Convert.ToString(symbol, 2), countByte);
        }
        public static int[] ByteToBinInt(string symbolBits, int countByte)
        {
            int[] numArray = new int[countByte * 8];
            string str = symbolBits;
            string str2 = string.Empty;
            for (int i = 0; i < (numArray.Length - str.Length); i++)
            {
                str2 = str2 + "0";
            }
            string str3 = str2 + str;
            for (int j = 0; j < str3.Length; j++)
            {
                numArray[j] = int.Parse(str3[j].ToString());
            }
            return numArray;
        }

        public static StringBuilder ByteToStringBuilderBoolean(byte symbol)
        {
            StringBuilder builder = new StringBuilder(string.Empty);
            bool[] flagArray = ByteToBinBoolean(symbol);
            for (int i = 0; i < flagArray.Length; i++)
            {
                if (flagArray[i])
                {
                    builder.Append('1');
                }
                else
                {
                    builder.Append('0');
                }
            }
            return builder;
        }
        public static StringBuilder ByteToStringBuilderBooleanNoPrefix(byte symbol)
        {
            StringBuilder builder = new StringBuilder(string.Empty);
            bool[] flagArray = ByteToBinBooleanNoPrefix(symbol);
            for (int i = 0; i < flagArray.Length; i++)
            {
                if (flagArray[i])
                {
                    builder.Append('1');
                }
                else
                {
                    builder.Append('0');
                }
            }
            return builder;
        }

        public static byte StringToByte(string builder)
        {
            bool[] mas = new bool[8];

            int i = 0;
            foreach (char c in builder.ToString())
                if (c == '0')
                    mas[i++] = false;
                else
                    mas[i++] = true;

            return BooleanToBin(mas);
        }

        public static BitArray TreeToBit(Tree tree)
        {
            Branch parent = tree.Root.Copy();

            List<int> list = new List<int>();

            while (true)
            {
                while (((parent.Left == null) && (parent.Right == null)) && ((parent.Parent != null) && parent.isEmptyBranch))
                {
                    parent.Delete();
                    parent = parent.Parent;
                }

                if (parent.Left == null && 
                    parent.Right == null &&
                    parent.Parent == null && 
                    parent.isEmptyBranch)
                    break;

                if (parent.isEmptyBranch)
                {
                    list.Add(0);
                    if (parent.Left != null)
                    {
                        parent = parent.Left;
                    }
                    else if (parent.Right != null)
                    {
                        parent = parent.Right;
                    }
                }
                else
                {
                    list.RemoveAt(list.Count - 1);
                    list.Add(1);
                    list.AddRange(ByteToBinInt(parent.Symbol));
                    parent.Delete();
                    parent = parent.Parent;
                }
            }
            int[] numArray = new int[list.Count];
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = list[i];
            }
            bool[] values = new bool[numArray.Length];
            for (int j = 0; j < numArray.Length; j++)
            {
                if (numArray[j] == 0)
                {
                    values[j] = false;
                }
                else
                {
                    values[j] = true;
                }
            }
            return new BitArray(values);
        }
    }
}

