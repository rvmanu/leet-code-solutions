using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Delete_Node_in_a_Linked_List
{
    class Delete_Node_in_a_Linked_List
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public class Solution
        {
            public void DeleteNode(ListNode node)
            {
                if (node.next != null)
                {
                    node.val = node.next.val;
                    node.next = node.next.next;
                }


                /*
                Complexity: O(N)
                var runner = node;
                while(node.next != null)
                {
                    node.val = node.next.val;
                    runner = node;
                    node = node.next;
                }

                runner.next = null;*/
            }
        }
    }
}
