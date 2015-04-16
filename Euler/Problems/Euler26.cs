using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler26
    {
        public static string Run()
        {
            BigInteger start;

            for (int i = 999; i > 0; i -= 2)
            {
                if (!isPrime(i))
                    continue;
                start = BigInteger.Pow(10, i - 1);
                start -= 1;
                start /= i;
                if (CheckString(start.ToString()))
                    return i.ToString();
            }
            return "";
        }

        public const int digits = 3;
        public static bool CheckString(string s)
        {
            var dict = new Dictionary<string, int>();
            for (int len = s.Length - 1; len > 0; len--)
            {
                for (int i = 0; i <= s.Length - len; i++)
                {
                    if (len > digits)
                        break;
                    string sub = s.Substring(i, len);
                    if (dict.ContainsKey(sub))
                        return len <= digits - 1;
                    else 
                        dict[sub] = i;
                }
                dict.Clear();
            }
            return true;
        }

        private static bool isPrime(long number)
        {
            double boundary = Math.Floor(Math.Sqrt(number));
            for (long i = 2; i <= boundary; ++i)
                if (number % i == 0) return false;
            return true;
        }
    }
}
