using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler14
    {
        public static string Run()
        {
            return GetLongestCollatz(1e6).ToString();
        }

        public static long GetLongestCollatz(double end)
        {
            long
                i,
                maxStart = 0,
                max = 0,
                copy = 0;
            long[] cache = new long[(int)end - 1];
            for (int start = 2; start <= end; start++)
            {
                if (cache[start - 2] > 0)
                    continue;

                i = 0;
                copy = start;
                while (copy > 1)
                {
                    if (copy <= end && cache[copy - 2] > 0)
                    {
                        i += cache[copy - 2];
                        break;
                    }

                    if (copy.isEven())
                        copy /= 2;
                    else
                        copy = copy * 3 + 1;
                    i++;
                }
                if (i > max)
                {
                    maxStart = start;
                    max = i;
                }
                cache[start - 2] = i;
            }
            return maxStart;
        }

        private static bool isEven(this long i)
        {
            return (i & 1) == 0;
        }
    }
}
