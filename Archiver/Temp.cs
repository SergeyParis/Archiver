/*

using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Lab_2.Trees
{
    public class Tree
    {
        #region Fields

        private Branch _root;

        private Dictionary<byte, int> _sortedList; // Only to Copy()

        private List<Branch> _tree;
        private Dictionary<Branch, int> _listAllSymbols;

        private BitArray _bitArray = null;
        private Dictionary<byte, short[]> _huffmanTableShort;
        private Dictionary<byte, bool[]> _huffmanTableBoolean;
        #endregion

        public List<Branch> Collections
        {
            get
            {
                List<Branch> collections = new List<Branch>();

                if (collections.Count == 0)
                    foreach (KeyValuePair<Branch, int> pair in _listAllSymbols)
                        collections.Add(pair.Key);

                return collections;
            }
        }
        public Branch Root => _root;
        public BitArray BinnaryCode => _bitArray;

        public Dictionary<byte, short[]> HuffmanTableShortShort => _huffmanTableShort;
        public Dictionary<byte, bool[]> HuffmanTableBoolean => _huffmanTableBoolean;

        private Tree() { }
        public Tree(Dictionary<byte, int> sortedList)
        {
            Dictionary<Branch, int> listAllSymbols = CreateBranches(sortedList);
            Dictionary<Branch, int> treeList = CreateTreeList(listAllSymbols);

            _tree = ConvertTree(treeList);
            _listAllSymbols = listAllSymbols;
            _sortedList = sortedList;

            _root = _tree.First();
        }

        public global::Lab_2.Trees.Tree Copy()
        {
            global::Lab_2.Trees.Tree newTree = new global::Lab_2.Trees.Tree();

            newTree._root = this._root;
            newTree._sortedList = this._sortedList;
            newTree._tree = this._tree;
            newTree._listAllSymbols = this._listAllSymbols;

            if (this._bitArray != null)
                newTree._bitArray = this._bitArray;

            return newTree;
        }

        public void BuidBinnaryCode()
        {
            _bitArray = WorkWithBits.TreeToBit(this);
        }

        public void BuildHuffmanTable()
        {
            _huffmanTableShort = new Dictionary<byte, short[]>();

            Branch currentRoot = this._root.Copy();
            Branch currentBranch = currentRoot;
            List<short> listBytecode = new List<short>();

            while (currentBranch.Parent != null ||
                   currentBranch.Left != null ||
                   currentBranch.Right != null)
            {
                if (currentBranch.isEmptyBranch == true &&
                    currentBranch.Left == null &&
                    currentBranch.Right == null)
                {
                    currentBranch.Delete();
                    currentBranch = currentRoot;

                    continue;
                }

                //
                // go on a tree
                //
                if (currentBranch.Left != null)
                {
                    currentBranch = currentBranch.Left;
                    listBytecode.Add(0);

                    continue;
                }
                if (currentBranch.Right != null)
                {
                    currentBranch = currentBranch.Right;
                    listBytecode.Add(1);

                    continue;
                }
                //
                // write bytecode
                //
                if (currentBranch.isEmptyBranch == false)
                {
                    short[] temp = new short[listBytecode.Count];

                    for (int i = 0; i < temp.Length; i++)
                        temp[i] = listBytecode[i];

                    _huffmanTableShort.Add(currentBranch.Symbol, temp);

                    currentBranch.Delete();

                    currentBranch = currentRoot;
                    listBytecode.Clear();
                }
            }

            BuildHuffmanTableBoolean();
        }
        private void BuildHuffmanTableBoolean()
        {
            _huffmanTableBoolean = new Dictionary<byte, bool[]>();

            foreach (KeyValuePair<byte, short[]> pair in HuffmanTableShortShort)
            {
                bool[] temp = new bool[pair.Value.Length];

                for (int i = 0; i < pair.Value.Length; i++)
                    if (pair.Value[i] == 0)
                        temp[i] = false;
                    else if (pair.Value[i] == 1)
                        temp[i] = true;

                _huffmanTableBoolean.Add(pair.Key, temp);
            }
        }

        private List<Branch> ConvertTree(Dictionary<Branch, int> treeList)
        {
            List<Branch> tree = new List<Branch>();

            foreach (KeyValuePair<Branch, int> pair in treeList)
                tree.Add(pair.Key);

            return tree;
        }

        private static Dictionary<Branch, int> CreateTreeList(Dictionary<Branch, int> dictionary)
        {


            while (dictionary.Count > 1)
            {
                KeyValuePair<Branch, int> firstRemove = dictionary.First();
                dictionary.Remove(dictionary.Keys.First());

                KeyValuePair<Branch, int> secondRamove = dictionary.First();
                dictionary.Remove(dictionary.Keys.First());

                KeyValuePair<Branch, int> newValue =
                    new KeyValuePair<Branch, int>
                    (new Branch(byte.MinValue, firstRemove.Key, secondRamove.Key) { isEmptyBranch = true },
                    firstRemove.Value + secondRamove.Value);

                firstRemove.Key.Parent = newValue.Key;
                secondRamove.Key.Parent = newValue.Key;

                dictionary.Add(newValue.Key, newValue.Value);

                /*
                {
                    Dictionary<Branch, int> tempDictionary = new Dictionary<Branch, int>();

                    var sortedList = dictionary.OrderBy(pair => pair.Value);

                    foreach (KeyValuePair<Branch, int> pair in sortedList)
                        tempDictionary.Add(pair.Key, pair.Value);

                    dictionary = tempDictionary;
                }
                */
               
                
                
                
                
                
                
                
                
                
                
                
                
                
                /*
                SortDictionary(dictionary);
            }

            /*
            dictionary.Clear();
            foreach (KeyValuePair<Branch, int> pair in dictionary)
                dictionary.Add(pair.Key, pair.Value);
            */














            /*
            return dictionary;
        }

        private class BranchSort : Branch
        {
            public int Priority = 0;

            public BranchSort(int priority, Branch thisBranch) : base(thisBranch.Symbol, thisBranch.Left, thisBranch.Right)
            {
                Priority = priority;
                this.Parent = thisBranch.Parent;
            }
        }
        private static void SortDictionary(Dictionary<Branch, int> dictionary)   //сортировка элементов дерева
        {
            List<global::Lab_2.Trees.Tree.BranchSort> sortedList = new List<global::Lab_2.Trees.Tree.BranchSort>();
            foreach (KeyValuePair<Branch, int> pair in dictionary)
                sortedList.Add(new global::Lab_2.Trees.Tree.BranchSort(pair.Value, pair.Key));

            for (int i = 0; i < sortedList.Count - 1; i++)
                for (int j = i; j < sortedList.Count; j++)
                    if (sortedList[i].Priority > sortedList[j].Priority)
                    {
                        global::Lab_2.Trees.Tree.BranchSort temp = sortedList[i];
                        sortedList[i] = sortedList[j];
                        sortedList[j] = temp;
                    }

            dictionary.Clear();
            foreach (global::Lab_2.Trees.Tree.BranchSort sort in sortedList)
                dictionary.Add(new Branch(sort.Symbol, sort.Left, sort.Right) { Parent = sort.Parent }, sort.Priority);
        }

        private static Dictionary<Branch, int> CreateBranches(Dictionary<byte, int> sortedList)
        {
            Dictionary<Branch, int> returnList = new Dictionary<Branch, int>();

            foreach (KeyValuePair<byte, int> pair in sortedList)
                returnList.Add(new Branch(pair.Key), pair.Value);

            return returnList;
        }
    }
}

*/