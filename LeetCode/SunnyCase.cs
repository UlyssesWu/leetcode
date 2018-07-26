using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class SunnyCase
    {
        public void ReachNumberTest()
        {
            var r = ReachNumber(7);
            r = ReachNumber(8);
            r = ReachNumber(9);
            r = ReachNumber(14);
        }
        public int ReachNumber(int target)
        {
            //ref: https://blog.csdn.net/wx734518351/article/details/80559412
            // 分析 首先考虑一种比较极端的情况 即一直向正方向移动n步 ，刚好达到target 
            // 那么target的值就等于前n步的和 ，也就是1+2+.....+n = n*(n+1)/2
            // 如果n(n+1)/2>target ,那么所需要的步数肯定要比n多，而且肯定有向左走的步子，也就是求和的时候肯定是有负数的，至于哪个或者哪些个为负，下面开始讨论
            //1，n(n+1)/2 - target 为偶数时，所以要想到达 target 需要向左走 n(n+1)/2 - target 偶数步 ，
            // 就是把前n项中第( n(n+1)/2 - target)/2 步变为负号就行了
            //当n(n+1)/2 - target 为奇数时，就要分类讨论了，若n为奇数n+1就是偶数 无论向左还是向右 都不会产生一个奇数的差来因此需要再走一步故要n+2步
            //若n为偶数，n+1则为奇数，可以产生一个奇数的差，故要n+1步
            if (target < 0)
            {
                target = -target;
            }

            if (target == 0)
            {
                return 0;
            }

            int n = 1;
            int len = 1;
            while (len < target)
            {
                n++;
                len = (n * (n + 1)) / 2;
            }

            if (len == target)
            {
                return n;
            }

            if ((len - target) % 2 == 0) //8 => -1,2,3,4
            {
                return n;
            }
            else
            {
                //9 => -1,-2,3,4,5
                //7 => 1,2,3,-4,5
                //14 => -1,(2,3,4,5),-6,7
                if (n % 2 == 0)
                {
                    return n + 1;
                }

                return n + 2;
            }
        }
    }
}
