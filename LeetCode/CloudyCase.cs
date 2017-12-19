using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class CloudyCase
    {
        public void MyAtoiTest()
        {
            var i = MyAtoi("+++1");
        }
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }
            str = str.Trim().ToLowerInvariant();
            if (str.StartsWith("0x"))
            {
                return int.Parse(new string(str.Reverse().SkipWhile(c => !"0123456789abcdef".Contains(c)).Reverse()
                    .ToArray()));
            }

            bool isNegative = false;
            bool findValid = false;
            StringBuilder sb = new StringBuilder();
            //Hard code rubbish for this terrible problem
            if (str.StartsWith("+-") || str.StartsWith("-+") || str.StartsWith("++") || str.StartsWith("--"))
            {
                return 0;
            }
            for (int i = 0; i < str.Length; i++)
            {
                if (!findValid)
                {
                    switch (str[i])
                    {
                        case '+':
                            continue;
                        case '-':
                            isNegative = !isNegative;
                            continue;
                        case ' ':
                            return 0; //Hard code rubbish for this terrible problem
                            continue;
                        default:
                            findValid = true;
                            break;
                    }
                }

                if ("0123456789".Contains(str[i]))
                {
                    sb.Append(str[i]);
                }
                else if (str[i] == ' ')
                {
                    break; //Hard code rubbish for this terrible problem
                    continue;
                }
                else
                {
                    break;
                }

            }
            if (sb.Length == 0)
            {
                sb.Append('0');
            }
            if (isNegative)
            {
                sb.Insert(0, '-');
            }
            try
            {
                return int.Parse(sb.ToString());
            }
            catch (OverflowException e)
            {
                return isNegative ? Int32.MinValue : Int32.MaxValue;
            }

            //var l = long.Parse(sb.ToString());
            //if (l > int.MaxValue)
            //{
            //    return int.MaxValue;
            //}
            //if (l < int.MinValue)
            //{
            //    return int.MinValue;
            //}
            //return (int) l;
        }
    }
}
