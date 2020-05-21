using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Middle_of_Linked_List
{
    class Middle_of_Linked_List
    {
        public ListNode MiddleNode(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            else if (head.next.next == null)
                return head.next;

            var node = head;
            var runner = head;
            while (runner != null && runner.next != null)
            {
                node = node.next;
                runner = runner.next.next;
            }

            return node;
        }
    }
}
