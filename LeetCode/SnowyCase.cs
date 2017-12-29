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

        public void FindCircleNumTest()
        {
            int[,] m = new int[3, 3] { { 1, 1, 0 }, { 1, 1, 1 }, { 0, 1, 1 } };
            var b = FindCircleNum(m);
            m = new int[3, 3] { { 1, 1, 0 }, { 1, 1, 0 }, { 0, 0, 1 } };
            b = FindCircleNum(m);
            m = new int[4, 4] {
                { 1, 0, 0, 1 },
                { 0, 1, 1, 0 },
                { 0, 1, 1, 1 },
                { 1, 0, 1, 1 }
            };
            b = FindCircleNum(m);
        }

        public int FindCircleNum(int[,] M)
        {
            int rank = M.GetUpperBound(0);
            List<int> cir = new List<int>(rank);
            List<int> init = new List<int>(rank);
            int count = 0;
            for (int i = 0; i <= rank; i++)
            {
                init.Add(i);
            }

            while (init.Count > 0)
            {
                Pick(init[0]);
                count++;
            }

            void Pick(int person)
            {
                init.Remove(person);
                cir.Add(person);
                for (int j = 0; j <= rank; j++)
                {
                    if (cir.Contains(j))
                    {
                        continue;
                    }

                    if (M[person, j] != 0)
                    {
                        Pick(j);
                    }
                }
            }

            return count;
        }

        //This is for another problem
        public int FindCircleNumWrong(int[,] M)
        {
            var yBound = M.GetUpperBound(1);
            var xBound = M.GetUpperBound(0);
            void FloodDestory(int x, int y)
            {
                if (M[x, y] != 0)
                {
                    M[x, y] = 0;
                    if (x - 1 >= 0 && M[x - 1, y] != 0)
                    {
                        FloodDestory(x - 1, y);
                    }
                    if (x + 1 <= xBound && M[x + 1, y] != 0)
                    {
                        FloodDestory(x + 1, y);
                    }
                    if (y - 1 >= 0 && M[x, y - 1] != 0)
                    {
                        FloodDestory(x, y - 1);
                    }
                    if (y + 1 <= yBound && M[x, y + 1] != 0)
                    {
                        FloodDestory(x, y + 1);
                    }
                }
            }

            int count = 0;
            for (int y = 0; y <= yBound; y++)
            {
                for (int x = 0; x <= xBound; x++)
                {
                    if (M[x, y] != 0)
                    {
                        FloodDestory(x, y);
                        count++;
                    }
                }
            }

            return count;
        }
        
        //Give my knees to RandomG
        //Just check UP-LEFT
        public int CountBattleships(char[,] board)
        {
            var count = 0;
            for (int y = 0; y < board.GetLength(1); y++)
            {
                for (int x = 0; x < board.GetLength(0); x++)
                {
                    if (board[x,y] == 'X')
                    {
                        if ((x == 0 || (board[x-1,y] != 'X')) && (y==0 || (board[x,y-1] != 'X')))
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
