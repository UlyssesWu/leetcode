using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class SnowyCase
    {
        public void ZigZagConversionTest()
        {
            var stopwatch = Stopwatch.StartNew();
            var result = ZigZagConversion("PAYPALISHIRING", 3);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
        }

        public string ZigZagConversion(string s, int numRows)
        {
            StringBuilder sb = new StringBuilder(s.Length);
            List<char>[] stack = new List<char>[numRows];
            for (int i = 0; i < numRows; i++)
            {
                stack[i] = new List<char>();
            }
            int ptr = 0;
            bool up = true;
            for (int j = 0; j < s.Length; j++)
            {
                stack[ptr].Add(s[j]);
                if (up && ptr < numRows - 1)
                {
                    ptr++;
                }
                else if (!up && ptr > 0)
                {
                    ptr--;
                }
                if (ptr == numRows - 1 || ptr == 0)
                {
                    up = !up;
                }
            }
            foreach (var st in stack)
            {
                sb.Append(st.ToArray());
            }
            return sb.ToString();
        }


    }
}
