using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler036
    {
        private const long max = (long)1e6;

        public static string Run()
        {
            double result = GenerateBinaryPalindromes()
                .Where(x => IsPalindrome(x))
                .Sum();
            return (++result).ToString();
        }

        private static bool IsPalindrome(long n)
        {
            long num, rem, sum = 0, temp;
            num = n;
            temp = num;
            while (Convert.ToBoolean(num))
            {
                rem = num % 10;
                num = num / 10; 
                sum = sum * 10 + rem; 
            }
            return temp == sum;
        }

        public static IEnumerable<long> GenerateBinaryPalindromes()
        {
            long 
                temp,
                cur = 0,
                i = 1;
            while (cur < max)
            {
                string bin = Convert.ToString(i, 2);

                cur = Convert.ToInt64(bin + Reverse(bin), 2);
                if (cur >= max) break;
                yield return cur;

                temp = Convert.ToInt64(bin + "0" + Reverse(bin), 2);
                if (temp < max)
                {
                    yield return temp;

                    temp = Convert.ToInt64(bin + "1" + Reverse(bin), 2);
                    if (temp < max)
                        yield return temp;
                }
                i++;
            }
        }

        private static string Reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
