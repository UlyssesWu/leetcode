using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
    }
}
