using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
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
        public void LengthOfLongestSubstringTest()
        {
            LengthOfLongestSubstring("bpfbhmipx");
        }
        public int LengthOfLongestSubstring(string s)
        {
            int length = 0;
            List<char> stack = new List<char>(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (stack.Contains(s[i]))
                {
                    if (stack.Count > length)
                    {
                        length = stack.Count;
                    }
                    var idx = stack.IndexOf(s[i]);
                    stack.RemoveRange(0, idx + 1);
                }
                stack.Add(s[i]);
                //var cc = new string(stack.ToArray());
            }
            if (stack.Count > length)
            {
                length = stack.Count;
            }
            return length;
        }

        public void FindMedianSortedArraysTest()
        {
            var answer = FindMedianSortedArrays(new int[] {1}, new[] {2,3,4});
        }
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            var aLen = nums1.Length;
            var bLen = nums2.Length;
            var total = aLen + bLen;
            var count = 0;
            var aPtr = 0;
            var bPtr = 0;

            //if (nums1.Length == 0 || nums2.Length == 0)
            //{
            //    goto LBL;
            //}

            //var aFirst = nums1[0];
            //var aLast = nums1[nums1.Length - 1];
            //var bFirst = nums2[0];
            //var bLast = nums2[nums2.Length - 1];

            //if (aLast < bFirst) //a < b
            //{
            //    if (aLen > bLen) //located in a
            //    {
            //        var id = Math.Ceiling(total / 2.0);
            //        return nums1[(int)id - 1];
            //    }
            //    else if (aLen == bLen)
            //    {
            //        return (aLast + bFirst) / 2.0;
            //    }
            //    else //located in b
            //    {
            //        var id = Math.Ceiling(total / 2.0);
            //        return nums2[(int)id - aLen - 1];
            //    }
            //}
            //if (aFirst > bLast) // a > b
            //{
            //    if (aLen < bLen) //located in b
            //    {
            //        var id = Math.Ceiling(total / 2.0);
            //        return nums2[(int)id - 1];
            //    }
            //    else if (aLen == bLen)
            //    {
            //        return (aLast + bFirst) / 2.0;
            //    }
            //    else //located in a
            //    {
            //        var id = Math.Ceiling(total / 2.0);
            //        return nums1[(int)id - bLen - 1];
            //    }
            //}
            //LBL:

            int pick;
            bool pickTwo = false;
            if (total % 2 == 0)
            {
                pick = total / 2;
                pickTwo = true;
            }
            else
            {
                pick = total / 2 + 1;
            }

            int pick1 = 0, pick2 = 0;
                
            void SelectA()
            {
                if (count == pick)
                {
                    pick1 = nums1[aPtr];
                }
                else if (pickTwo && count == pick + 1)
                {
                    pick2 = nums1[aPtr];
                }
                aPtr++;
            }

            void SelectB()
            {
                if (count == pick)
                {
                    pick1 = nums2[bPtr];
                }
                else if (pickTwo && count == pick + 1)
                {
                    pick2 = nums2[bPtr];
                }
                bPtr++;
            }

            while (true)
            {
                count++;
                if (count > pick + 1 || (!pickTwo && count > pick))
                {
                    break;
                }
                if (bPtr >= nums2.Length)
                {
                    SelectA();
                }
                else if (aPtr >= nums1.Length)
                {
                    SelectB();
                }
                else if (nums1[aPtr] < nums2[bPtr])
                {
                    SelectA();
                }
                else
                {
                    SelectB();
                }

            }
            if (pickTwo)
            {
                return (pick1 + pick2) / 2.0;
            }
            return pick1;
        }

        public void LongestPalindromeTest()
        {
            var result = LongestPalindrome("DBCCBD");
        }

        public string LongestPalindrome(string s)
        {
            int maxLen = 0;
            string pStr = null;
            int Palindrome(int idx)
            {
                int len = 1;

                while (idx + len < s.Length && idx - len >= 0 && s[idx + len] == s[idx - len])
                {
                    len++;
                }
                return 2 * len - 1;
            }

            int PalindromeD(int idx)
            {
                // B D C C D B
                // 0 1 2 3 4 5
                int len = 0;

                while (idx + len + 1 < s.Length && idx - len >= 0 && s[idx + len + 1] == s[idx - len])
                {
                    len++;
                }
                return 2 * len;
            }
            for (int i = 0; i < s.Length; i++)
            {
                var len = Palindrome(i);
                if (len > maxLen)
                {
                    maxLen = len;
                    pStr = s.Substring(i - len / 2, len);
                }
                len = PalindromeD(i);
                if (len > maxLen)
                {
                    maxLen = len;
                    pStr = s.Substring(i - len / 2 + 1, len);
                }
            }
            return pStr;
        }

    }
}
