using System.Windows.Forms.VisualStyles;

namespace Lab_2.Trees
{
    using Lab_2;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree
    {
        private BitArray _bitArray;

        #region fields
        private Dictionary<byte, int[]> _huffmanTable;

        private List<Branch> _listAllSymbols;
        private Branch _root;
        private Dictionary<byte, int> _sortedList;
        #endregion

        #region properties
        public BitArray BinnaryCode => this._bitArray;
        public List<Branch> Collections => this._listAllSymbols;

        public Dictionary<byte, int[]> HuffmanTable => this._huffmanTable;

        public Branch Root => this._root;
        #endregion

        private Tree()
        {
        }
        public Tree(int[] list)
        {
            Dictionary<byte, int> sortedList = new Dictionary<byte, int>(list.Length);

            for (int i = 0; i < list.Length; i++)
                sortedList.Add(Convert.ToByte(i), list[i]);

            WorkWithBytes.SortDictionary(ref sortedList);

            List<Branch> listB = CreateBranches(sortedList);
            CreateTreeList(ref listB);
            this._listAllSymbols = listB;
            this._sortedList = sortedList;
            this._root = this._listAllSymbols.First<Branch>();
        }
        public Tree(Dictionary<byte, int> sortedList)
        {
            List<Branch> list = CreateBranches(sortedList);
            CreateTreeList(ref list);
            this._listAllSymbols = list;
            this._sortedList = sortedList;
            this._root = this._listAllSymbols.First<Branch>();
        }
        public Tree(bool[] bits)
        {
            this._root = this.ParseBitTree(bits);
        }

        public void BuildBinnaryCode()
        {
            this._bitArray = WorkWithBits.TreeToBit(this);
        }

        public void BuildHuffmanTable()
        {
            this._huffmanTable = new Dictionary<byte, int[]>();

            Branch root = this._root.Copy();
            Branch currentBranch = root;

            List<short> list = new List<short>();

            while (((currentBranch.Parent != null) || (currentBranch.Left != null)) || (currentBranch.Right != null))
            {
                if ((currentBranch.isEmptyBranch && (currentBranch.Left == null)) && (currentBranch.Right == null))
                {
                    currentBranch.Delete();
                    currentBranch = root;
                    list.Clear();
                }
                else
                {
                    if (currentBranch.Left != null)
                    {
                        currentBranch = currentBranch.Left;
                        list.Add(0);
                        continue;
                    }
                    if (currentBranch.Right != null)
                    {
                        currentBranch = currentBranch.Right;
                        list.Add(1);
                        continue;
                    }

                    if (!currentBranch.isEmptyBranch)
                    {
                        int[] numArray = new int[list.Count];
                        for (int i = 0; i < numArray.Length; i++)
                            numArray[i] = list[i];

                        this._huffmanTable.Add(currentBranch.Symbol, numArray);

                        currentBranch.Delete();
                        currentBranch = root;
                        list.Clear();
                    }
                }
            }

        }

        public Tree Copy()
        {
            Tree tree = new Tree
            {
                _root = this._root,
                _sortedList = this._sortedList,
                _listAllSymbols = this._listAllSymbols
            };
            if (this._bitArray != null)
            {
                tree._bitArray = this._bitArray;
            }
            return tree;
        }

        private static List<Branch> CreateBranches(Dictionary<byte, int> sortedList)
        {
            List<Branch> list = new List<Branch>();
            foreach (KeyValuePair<byte, int> pair in sortedList)
            {
                Branch item = new Branch(pair.Key)
                {
                    Priority = pair.Value
                };
                list.Add(item);
            }
            return list;
        }
        private static void CreateTreeList(ref List<Branch> list)
        {
            while (list.Count > 1)
            {
                Branch left = list[0];
                Branch right = list[1];
                list.RemoveAt(0);
                list.RemoveAt(0);
                Branch item = new Branch(0, left, right)
                {
                    isEmptyBranch = true,
                    Priority = left.Priority + right.Priority
                };
                left.Parent = item;
                right.Parent = item;
                list.Add(item);
                SortDictionary(list);
            }
        }

        private Branch ParseBitTree(bool[] bits)
        {
            Branch root = new Branch(0) { isEmptyBranch = true };
            Branch currentBranch = root;

            int index = 0;
            while (index < bits.Length)
            {
                while ((currentBranch.Left != null) && (currentBranch.Right != null))
                {
                    if (currentBranch.Parent == null)
                    {
                        return root;
                    }
                    currentBranch = currentBranch.Parent;
                }
                if (!bits[index])
                {
                    if (currentBranch.Left == null)
                    {
                        Branch branch3 = new Branch(0)
                        {
                            isEmptyBranch = true,
                            Parent = currentBranch
                        };
                        currentBranch.Left = branch3;
                        currentBranch = currentBranch.Left;
                        index++;
                    }
                    else
                    {
                        Branch branch4 = new Branch(0)
                        {
                            isEmptyBranch = true,
                            Parent = currentBranch
                        };
                        currentBranch.Right = branch4;
                        currentBranch = currentBranch.Right;
                        index++;
                    }
                }
                else
                {
                    index++;
                    if (currentBranch.Left == null)
                    {
                        bool[] bools = new bool[8];
                        int num2 = 0;
                        while (num2 < 8)
                        {
                            if (index < bits.Length)
                            {
                                bools[num2] = bits[index];
                            }
                            else
                            {
                                bools[num2] = false;
                            }
                            num2++;
                            index++;
                        }
                        Branch branch5 = new Branch(WorkWithBits.BooleanToBin(bools))
                        {
                            isEmptyBranch = false,
                            Parent = currentBranch
                        };
                        currentBranch.Left = branch5;

                    }
                    else
                    {
                        bool[] flagArray2 = new bool[8];
                        int num3 = 0;
                        while (num3 < 8)
                        {
                            if (index < bits.Length)
                            {
                                flagArray2[num3] = bits[index];
                            }
                            else
                            {
                                flagArray2[num3] = false;
                            }
                            num3++;
                            index++;
                        }
                        Branch branch6 = new Branch(WorkWithBits.BooleanToBin(flagArray2))
                        {
                            isEmptyBranch = false,
                            Parent = currentBranch
                        };
                        currentBranch.Right = branch6;

                    }
                }
            }
            return root;
        }

        private static void SortDictionary(List<Branch> list)
        {
            for (int i = 0; i < (list.Count - 1); i++)
            {
                for (int j = i; j < list.Count; j++)
                {
                    if (list[i].Priority > list[j].Priority)
                    {
                        Branch branch = list[i];
                        list[i] = list[j];
                        list[j] = branch;
                    }
                }
            }
        }
    }
}

