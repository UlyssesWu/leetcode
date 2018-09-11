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
            BitArray primeArr = new BitArray(i + 1, true) {[1] = false};
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
            var head = reConstructBinaryTree(new[] {1, 2, 4, 5, 8, 9, 3, 6, 7}, new[] {4, 2, 8, 5, 9, 1, 6, 3, 7});
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
    }
}
