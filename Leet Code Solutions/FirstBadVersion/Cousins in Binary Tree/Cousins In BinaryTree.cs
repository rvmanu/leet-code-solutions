using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Cousins_in_Binary_Tree
{
    class Cousins_In_BinaryTree
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        #region Pre-Order Traversal and Depth Calculation
        public bool IsCousins(TreeNode root, int x, int y)
        {
            // Get the TreeNode object corresponds to the value x's parent
            var xParentNode = GetNode(root, x);

            // Get the TreeNode object corresponds to the value y's parent
            var yParentNode = GetNode(root, y);

            // If any of the node doesnt found, then no cousins exists
            if (xParentNode == null || yParentNode == null)
            {
                return false;
            }

            // If the nodes found, but the values are same (both are same node) then the nodes are not cousins
            if (xParentNode == yParentNode || xParentNode.val == yParentNode.val)
            {
                return false;
            }

            // When the nodes are from different parents and the depths are not same, they are not cousins
            return GetDepth(root, x) == GetDepth(root, y);
        }

        private TreeNode GetNode(TreeNode node, int value)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.left != null && node.left.val == value)
            {
                return node;
            }
            else if (node.right != null && node.right.val == value)
            {
                return node;
            }

            var result = GetNode(node.left, value);
            if (result != null)
            {
                return result;
            }

            result = GetNode(node.right, value);
            return result;
        }

        private int GetDepth(TreeNode node, int value)
        {
            if (node == null)
            {
                return int.MinValue;
            }
            else if (node.val == value)
            {
                return 0;
            }

            return 1 + Math.Max(GetDepth(node.left, value), GetDepth(node.right, value));
        }
        #endregion

        #region Pre-Order Traversal along with Depth Calculation (Update static variable from recursion)
        public static int nodeDepth = 0;
        public bool IsCousins2(TreeNode root, int x, int y)
        {
            var xParentNode = GetNode(root, x, 0);
            var xDepth = Cousins_In_BinaryTree.nodeDepth;

            var yParentNode = GetNode(root, y, 0);
            var yDepth = Cousins_In_BinaryTree.nodeDepth;
            if (xParentNode == null || yParentNode == null)
            {
                return false;
            }

            if (xParentNode == yParentNode || xParentNode.val == yParentNode.val)
            {
                return false;
            }

            return xDepth == yDepth;
        }

        private TreeNode GetNode(TreeNode node, int value, int depth)
        {
            if (node == null)
            {
                return null;
            }
            else if (node.left != null && node.left.val == value)
            {
                Cousins_In_BinaryTree.nodeDepth = depth;
                return node;
            }
            else if (node.right != null && node.right.val == value)
            {
                Cousins_In_BinaryTree.nodeDepth = depth;
                return node;
            }

            var result = GetNode(node.left, value, depth + 1);
            if (result != null)
            {
                return result;
            }

            result = GetNode(node.right, value, depth + 1);
            return result;
        }
        #endregion
    }
}
