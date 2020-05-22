using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Kth_Smallest_Element_in_a_BST
{
    public class Kth_Smallest_Element_in_a_BST
    {
        public int KthSmallest(TreeNode root, int k)
        {
            if (root == null || k < 1)
            {
                return -1;
            }

            nodeCount = 0;
            int minValue = 0;
            GetInOrderNode(root, k, ref minValue);
            return minValue;
        }

        #region In-Order Traversal With Recursion
        private static int nodeCount = 0;
        private int GetInOrderNode(TreeNode node, int k, ref int minValue)
        {
            if (node == null)
            {
                return 0;
            }

            var leftCount = GetInOrderNode(node.left, k, ref minValue);
            leftCount++;
            if (leftCount == k)
            {
                Console.Write(leftCount + " ");
                minValue = node.val;
            }

            var rightCount = GetInOrderNode(node.right, k, ref minValue);
            return leftCount + rightCount;
        }
        #endregion

        #region In-Order Traversal Without Recursion
        private TreeNode GetInorderNode(TreeNode node, int k)
        {
            var stack = new Stack<TreeNode>();
            var runner = node;
            int count = 0;
            while (runner != null || stack.Count > 0)
            {
                while (runner != null)
                {
                    stack.Push(runner);
                    runner = runner.left;
                }

                runner = stack.Pop();
                count++;
                if (count == k)
                {
                    return runner;
                }

                runner = runner.right;
            }

            return null;
        }
        #endregion

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

    }
}
