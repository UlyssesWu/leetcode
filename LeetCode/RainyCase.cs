using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class RainyCase
    {
        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] { i, j };
                    }
                }
            }
            return new int[] { };
        }


        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public void AddTwoNumbersTest()
        {
            //Alive makes me alive.
            ListNode l1 = new ListNode(1){next = new ListNode(8)};
            ListNode l2 = new ListNode(0);
            Stopwatch stopwatch = Stopwatch.StartNew();
            AddTwoNumbers(l1, l2);
            stopwatch.Stop();
            var time = stopwatch.ElapsedTicks; // 13000

            stopwatch = Stopwatch.StartNew();
            AddTwoNumbers2(l1, l2);
            stopwatch.Stop();
            time = stopwatch.ElapsedTicks; // 1300
        }

        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            ListNode currentNode = null;
            ListNode firstNode = null;
            var add = 0;
            while (l1 != null || l2 != null || add != 0)
            {
                var current = add + (l1?.val ?? 0) + (l2?.val ?? 0);
                if (current > 9)
                {
                    current -= 10;
                    add = 1;
                }
                else
                {
                    add = 0;
                }
                ListNode l = new ListNode(current);
                if (currentNode != null)
                {
                    currentNode.next = l;
                }
                else
                {
                    firstNode = l;
                }
                currentNode = l;
                l1 = l1?.next;
                l2 = l2?.next;
            }
            return firstNode;
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            StringBuilder sb = new StringBuilder();
            while (l1 != null)
            {
                sb.Insert(0, l1.val + '0');
                l1 = l1.next;
            }
            var a = int.Parse(sb.ToString());
            sb.Clear();

            while (l2 != null)
            {
                sb.Insert(0, l2.val + '0');
                l2 = l2.next;
            }
            var b = int.Parse(sb.ToString());

            a = a + b;

            var s = a.ToString();

            //123 = 3 -> 2 -> 1
            ListNode nodeResult = null;
            ListNode current = null;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                var node = new ListNode(s[i] - '0');
                if (nodeResult == null)
                {
                    nodeResult = node;
                    current = node;
                }
                else
                {
                    current.next = node;
                    current = node;
                }
            }

            return nodeResult;
        }

    }
}
