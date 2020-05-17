using System;
using System.Collections.Generic;
using System.Text;

namespace FirstBadVersion.Odd_Even_Linked_List
{
    class Odd_Even_Linked_List
    {
        public ListNode OddEvenList(ListNode head)
        {
            if (head == null)
                return null;

            ListNode evenHead = head.next;
            ListNode oddNode = head;
            ListNode evenNode = head.next;
            while (oddNode.next != null && oddNode.next.next != null)
            {
                oddNode.next = oddNode.next.next;        //3
                oddNode = oddNode.next;

                if (evenNode.next != null)
                {
                    evenNode.next = evenNode.next.next;      //4    
                    evenNode = evenNode.next;
                }
            }

            oddNode.next = evenHead;
            return head;
        }

        public ListNode OddEvenList2(ListNode head)
        {
            if (head == null)
                return null;

            ListNode odd = head;
            ListNode evenHead = head.next;
            ListNode even = head.next;

            while (even != null && even.next != null)
            {
                odd.next = even.next;
                odd = odd.next;
                even.next = odd.next;
                even = even.next;
            }

            odd.next = evenHead;
            return head;
        }

        private class ListNode
        {
            public int val { get; set; }
            public ListNode next { get; set; }
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }
    }
}
