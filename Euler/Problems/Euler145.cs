using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler145
    {
        public static string Run()
        {
            const long max = (long)1e8;
            int count = 0;
            for (long i = max + 1; i > 0; i -= 2)
            {
                long result = i + GetReverse(i);
                if ((result & 1) == 1 && OnlyUneven(result))
                    count++;
            }
            count *= 2;
            return count.ToString();
        }

        private static bool OnlyUneven(long n)
        {
            long
                num = n,
                rem;
            while (num > 0)
            {
                rem = num % 10;
                if ((rem & 1) == 0)
                    return false;
                num /= 10;
            }
            return true;
        }

        private static long GetReverse(long n)
        {
            long 
                num = n, 
                rem, 
                sum = 0;
            while (num > 0)
            {
                rem = num % 10;
                num = num / 10;
                sum = sum * 10 + rem;
            }
            return sum;
        }
    }
}
