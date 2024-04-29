namespace day13proj
{
    public class Minimum_depth_of_binary_tree 
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static async Task<int> MinDepth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            if (root.left == null && root.right == null)
            {
                return 1;
            }
            if (root.left == null)
            {
                return await MinDepth(root.right) + 1;
            }
            if (root.right == null)
            {
                return await MinDepth(root.left) + 1;
            }
            return Math.Min(await MinDepth(root.left), await MinDepth(root.right)) + 1;
        }
        
        static async Task Main(string[] args)
        {
            TreeNode root = new TreeNode(3);
            root.left = new TreeNode(9);
            root.right = new TreeNode(20);
            root.right.left = new TreeNode(15);
            root.right.right = new TreeNode(7);
            Console.WriteLine(await MinDepth(root));
        }
    }
}
