using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LeetCode.Common;

namespace LeetCode.Nowcoder
{
    class RandomG
    {

        //public static void Main()
        //{
        //    var input = int.Parse(Console.ReadLine());
        //    Console.WriteLine(GuessNum(input));
        //}

        public static void GuessNumTest()
        {
            var r = GuessNum(1000000);
        }

        // https://www.nowcoder.com/questionTerminal/0a5b316cfe9d4c4ba89c6c57a1ee516e
        public static ulong GuessNum(int i)
        {
            //数论：筛法求范围内质数
            BitArray primeArr = new BitArray(i + 1, true) { [1] = false };
            for (int k = 2; k <= Math.Sqrt(i); k++)
            {
                for (int j = k; j * k <= i; j++)
                {
                    primeArr[j * k] = false;
                }
            }

            List<int> counts = new List<int>();
            for (int j = 1; j <= i; j++)
            {
                if (primeArr[j])
                {
                    var powTime = 1;
                    while (Math.Pow(j, powTime) <= i)
                    {
                        powTime++;
                    }
                    counts.Add(powTime);
                }
            }

            ulong result = 1;
            foreach (var c in counts)
            {
                result = result * (ulong)c % 1000000007UL;
            }

            return (result);
        }

        public void FindTest()
        {

        }
        public bool Find(int target, int[][] array)
        {
            // write code here
            return array.Any(a => a.Contains(target));
        }

        public bool Find2(int target, int[][] array)
        {
            // write code here
            var x = array[0].Length - 1;
            var y = 0;
            while (x >= 0 && y >= 0 && y < array.Length && x < array[0].Length)
            {
                if (array[y][x] == target)
                {
                    return true;
                }
                if (array[y][x] < target)
                {
                    y++;
                }
                else if (array[y][x] > target)
                {
                    x--;
                }
            }

            return false;
        }

        public string replaceSpace(string str)
        {
            return str.Replace(" ", "%20");
        }

        public string replaceSpace2(string str)
        {
            int spaceCount = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            if (spaceCount == 0)
            {
                return str;
            }

            StringBuilder sb = new StringBuilder(str.Length + spaceCount * 2);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    sb.Append("%20");
                }
                else
                {
                    sb.Append(str[i]);
                }
            }

            return sb.ToString();
        }

        public void TestReconstruct()
        {
            var head = reConstructBinaryTree(new[] { 1, 2, 4, 5, 8, 9, 3, 6, 7 }, new[] { 4, 2, 8, 5, 9, 1, 6, 3, 7 });
            //var a = head.val;
            //a = head.left.val;
            //a = head.left.left.val;
            //a = head.left.right.val;
            //a = head.left.right.left.val;
            //a = head.left.right.right.val;
            //a = head.right.val;
            //a = head.right.left.val;
            //a = head.right.right.val;
            //a = head.right.left.left.val;
            //var head = reConstructBinaryTree(new[] { 1, 2, 4, 3, 5, 6 }, new[] { 4, 2, 1, 5, 3, 6 });
            var a = head.val;
            a = head.left.val;

        }

        public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        {
            //P171
            //front: 1,2,4,5,8,9,3,6,7
            //middle:4,2,8,5,9,1,6,3,7
            // write code here
            return Reconstruct(pre.ToList(), tin.ToList());
        }

        public TreeNode Reconstruct(IList<int> pre, IList<int> tin)
        {
            if (pre.Count == 0)
            {
                return null;
            }
            TreeNode head = new TreeNode(pre[0]);
            var index = tin.IndexOf(head.val);
            var leftPre = pre.Skip(1).Take(index).ToList();
            var leftTin = tin.Take(index).ToList();
            head.left = Reconstruct(leftPre, leftTin);
            //var remain = tin.Count - 1 - index;
            var rightPre = pre.Skip(1 + index).ToList();
            var rightTin = tin.Skip(index + 1).ToList();
            head.right = Reconstruct(rightPre, rightTin);
            return head;
        }

        public Stack<int> _stack1 = new Stack<int>();
        public Stack<int> _stack2 = new Stack<int>();

        public void TestStack()
        {
            push(1);
            push(2);
            var r = pop();
        }
        public void push(int node)
        {
            _stack1.Push(node);
        }
        public int pop()
        {
            if (_stack2.Count <= 0)
            {
                while (_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
            return _stack2.Pop();
        }

        public int minNumberInRotateArray(int[] rotateArray)
        {
            // write code here
            //return rotateArray.Min();
            if (rotateArray.Length == 0) return 0;
            for (var i = 1; i < rotateArray.Length; i++)
            {
                if (rotateArray[i] < rotateArray[i - 1])
                    return rotateArray[i];
            }
            return rotateArray[0];
        }

        public int jumpFloor(int number)
        {
            // write code here
            if (number < 1)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }

            if (number == 2)
            {
                return 2;
            }
            //N: N-1 jmp 1; N-2 jmp 2; therefore (N-1)+(N-2)

            return jumpFloor(number - 2) + jumpFloor(number - 1);
        }

        public int jumpFloorII(int number)
        {
            // write code here
            if (number < 1)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }

            if (number == 2)
            {
                return 2;
            }

            return 2 * jumpFloorII(number - 1);
        }

        public int rectCover(int number)
        {
            // write code here
            if (number < 1)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }

            if (number == 2)
            {
                return 2;
            }

            return rectCover(number - 1) + rectCover(number - 2);
        }

        public int NumberOf1(int n)
        {
            return Convert.ToString(n, 2).Count(c => c == '1');
        }

        public void PowerTest()
        {
            var ans = Power(2.0, 3);
        }

        public double Power(double thebase, int exponent)
        {
            //return Math.Pow(thebase, exponent);
            if (thebase == 0.0)
            {
                return 0.0;
            }
            long p = Math.Abs(exponent);
            double r = 1.0;
            while (p != 0)
            {
                if ((p & 1) != 0) r *= thebase;
                thebase *= thebase;
                p >>= 1;
            }

            return ( exponent < 0 ? 1.0 / r : r );
        }

        public int[] reOrderArray(int[] array)
        {
            // write code here
            var g = array.GroupBy(i => i % 2 == 0);
            if (g.Count() <= 1)
            {
                return array;
            }

            var result = g.First().Key ? g.Last().Concat(g.First()) : g.First().Concat(g.Last());
            return result.ToArray();
        }

        public ListNode FindKthToTail(ListNode head, int k)
        {
            // write code here
            int count = 0;
            ListNode node = head;
            while (node != null)
            {
                count++;
                node = node.next;
            }

            if (k > count || k < 0)
            {
                return null;
            }
            var index = count - k;
            node = head;
            for (int i = 0; i < index; i++)
            {
                node = node?.next;
            }

            return node;
        }

        public void ReverseListTest()
        {
            ListNode ln = new ListNode(1);
            ln.next = new ListNode(2);
            ln.next.next = new ListNode(3);
            var l = ReverseList(ln).val;
        }

        public ListNode ReverseList(ListNode pHead)
        {
            // write code here
            if (pHead == null)
                return null;
            ListNode pCur = pHead;
            ListNode pNext = pHead?.next;
            pHead.next = null;
            while (pNext != null)
            {
                var pNn = pNext.next;
                pNext.next = pCur;
                pCur = pNext;
                pNext = pNn;
            }

            return pCur;
        }
    }
}
