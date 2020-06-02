using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Invert_a_Binary_Tree
{
    class Invert_a_Binary_Tree
    {
        public class Solution
        {
            //* Definition for a binary tree node.
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

            public TreeNode InvertTree(TreeNode root)
            {
                PreOrder(root);
                //PostOrder(root);
                return root;
            }

            #region PreOrder Traversal
            public TreeNode InvertTree(TreeNode root)
            {
                if (root == null || root.left == null && root.right == null)
                    return root;

                var temp = root.left;
                root.left = root.right;
                root.right = temp;
                InvertTree(root.left);
                InvertTree(root.right);
                return root;
            }

            private void PreOrder(TreeNode node)
            {
                if (node == null || (node.left == null && node.right == null))
                    return;

                PreOrder(node.left);
                PreOrder(node.right);
                var temp = node.left;
                node.left = node.right;
                node.right = temp;
            }
            #endregion

            #region PostOrder Traversal
            private void PostOrder(TreeNode node)
            {
                if (node == null || node.left == null && node.right == null)
                    return;

                PostOrder(node.left);
                PostOrder(node.right);
                var temp = node.left;
                node.left = node.right;
                node.right = temp;
            }
            #endregion
        }
    }
}
