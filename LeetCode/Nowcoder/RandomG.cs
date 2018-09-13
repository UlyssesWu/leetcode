using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public int RectCover(int number)
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

            return RectCover(number - 1) + RectCover(number - 2);
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

            return (exponent < 0 ? 1.0 / r : r);
        }

        public int[] ReOrderArray(int[] array)
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

        public void MergeTest()
        {
            ListNode p1 = new ListNode(1);
            p1.next = new ListNode(3);
            p1.next.next = new ListNode(5);

            ListNode p2 = new ListNode(2);
            p2.next = new ListNode(4);
            p2.next.next = new ListNode(6);

            var p = Merge(p1, p2);
        }

        public ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            // write code here
            if (pHead1 == null)
            {
                return pHead2;
            }

            if (pHead2 == null)
            {
                return pHead1;
            }
            var p1 = pHead1;
            var p2 = pHead2;
            ListNode p = null;
            if (pHead1.val <= pHead2.val)
            {
                p = pHead1;
                p1 = pHead1.next;
            }
            else
            {
                p = pHead2;
                p2 = pHead2.next;
            }

            var head = p;
            while (p1 != null || p2 != null)
            {
                if (p1 == null)
                {
                    p.next = p2;
                    p = p.next;
                    p2 = p2.next;
                }
                else if (p2 == null)
                {
                    p.next = p1;
                    p = p.next;
                    p1 = p1.next;
                }
                else
                {
                    if (p1.val > p2.val)
                    {
                        p.next = p2;
                        p = p.next;
                        p2 = p2.next;
                    }
                    else
                    {
                        p.next = p1;
                        p = p.next;
                        p1 = p1.next;
                    }
                }
            }

            return head;
        }

        public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
        {
            // write code here
            if (pRoot1 == null || pRoot2 == null)
            {
                return false;
            }

            return ContainsSubTree(pRoot1, pRoot2);
        }

        public bool ContainsSubTree(TreeNode pRoot1, TreeNode pRoot2)
        {
            return Check(pRoot1, pRoot2) || HasSubtree(pRoot1.left, pRoot2) || HasSubtree(pRoot1.right, pRoot2);
        }

        public bool Check(TreeNode t1, TreeNode t2)
        {
            if (t2 == null)
            {
                return true;
            }

            if (t1 == null || t1.val != t2.val)
            {
                return false;
            }

            return Check(t1.left, t2.left) && Check(t1.right, t2.right);
        }

        public void PrintMatrixTest()
        {
            int[][] m = new int[4][]
                {new[] {1, 2, 3, 4}, new[] {5, 6, 7, 8}, new[] {9, 10, 11, 12}, new[] {13, 14, 15, 16}};
            //int[][] m = new int[1][]
            //    {new[] {1}};
            var r = printMatrix(m);
        }

        public List<int> printMatrix(int[][] matrix)
        {
            int rows = matrix.Length;
            int columns = matrix[0].Length;
            int start = 0;
            List<int> list = new List<int>();
            while (rows > start * 2 && columns > start * 2)
            {
                printMatrixInCircle(matrix, rows, columns, start, list);
                start++;
            }
            return list;
        }

        public void printMatrixInCircle(int[][] matrix, int rows, int columns, int start, List<int> list)
        {
            // 从左到右打印一行
            for (int i = start; i < columns - start; i++)
                list.Add(matrix[start][i]);
            // 从上到下打印一列
            for (int j = start + 1; j < rows - start; j++)
                list.Add(matrix[j][columns - start - 1]);
            // 从右到左打印一行
            for (int m = columns - start - 2; m >= start && rows - start - 1 > start; m--)
                list.Add(matrix[rows - start - 1][m]);
            // 从下到上打印一列
            for (int n = rows - start - 2; n >= start + 1 && columns - start - 1 > start; n--)
                list.Add(matrix[n][start]);
        }

        public bool IsPopOrder(int[] pushV, int[] popV)
        {
            // write code here
            if (pushV.Length == 0)
            {
                return false;
            }

            if (pushV.Length != popV.Length)
            {
                return false;
            }

            Stack<int> s = new Stack<int>();
            int i = 0, j = 0;
            while (i < pushV.Length)
            {
                s.Push(pushV[i++]);
                while (j < popV.Length && s.Peek() == popV[j])
                {
                    s.Pop();
                    j++;
                }
            }

            return s.Count == 0;
        }
    }
}
