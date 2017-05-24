namespace Lab_2.Trees
{
    public class Branch
    {
        public Branch Left;
        public Branch Right;
        public Branch Parent;

        public byte Symbol;
        public int Priority;
        public bool isEmptyBranch = false;

        public Branch() : this (byte.MinValue) { }
        public Branch(byte symbol) : this (symbol, null, null) { }
        public Branch(byte symbol, Branch left, Branch right)
        {
            Symbol = symbol;

            Left = left;
            Right = right;

            Parent = null;
        }

        public Branch Copy()
        {
            return Copy(null);
        }
        private Branch Copy(Branch parent)
        {
            Branch branch = new Branch();

            branch.Symbol = this.Symbol;
            branch.isEmptyBranch = this.isEmptyBranch;

            if (this.Left != null)
                branch.Left = this.Left.Copy(branch);
            if (this.Right != null)
                branch.Right = this.Right.Copy(branch);

            if (parent != null)
                branch.Parent = parent;

            return branch;
        }

        public void Delete()
        {
            if (this == Parent.Left)
                Parent.Left = null;
            else if (this == Parent.Right)
                Parent.Right = null;
        }
    }
}
