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
            return (CountBinaryPalindromes() + 1).ToString();
        }

        private static bool IsPalindrome(int n)
        {
            int 
                num = n, 
                rem, 
                sum = 0;
            while (Convert.ToBoolean(num))
            {
                rem = num % 10;
                num = num / 10; 
                sum = sum * 10 + rem; 
            }
            return n == sum;
        }

        public static int CountBinaryPalindromes()
        {
            int 
                temp,
                cur = 0,
                i = 1,
                sum = 0;
            while (cur < max)
            {
                string bin = Convert.ToString(i, 2);

                cur = Convert.ToInt32(bin + Reverse(bin), 2);
                if (cur >= max) break;
                if (IsPalindrome(cur)) 
                    sum += cur;

                temp = Convert.ToInt32(bin + "0" + Reverse(bin), 2);
                if (temp < max)
                {
                    if (IsPalindrome(temp))
                        sum += temp;

                    temp = Convert.ToInt32(bin + "1" + Reverse(bin), 2);
                    if (temp < max)
                        if (IsPalindrome(temp))
                            sum += temp;
                }
                i++;
            }
            return sum;
        }

        private static string Reverse(string s)
        {
            return new string(s.Reverse().ToArray());
        }
    }
}
