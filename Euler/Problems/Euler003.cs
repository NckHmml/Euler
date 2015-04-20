using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler003
    {
        public static string Run()
        {
            long 
                max = 0,
                a = 600851475143;

            double boundary = Math.Floor(Math.Sqrt(a));

            for (long b = 1; b < boundary; b++)
            {
                if (GetGCD(a, b) == b && isPrime(b))
                    max = b;
            }
            return max.ToString();
        }

        private static long GetGCD(long a, long b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            if (a == 0)
                return b;
            else
                return a;
        }

        private static bool isPrime(long number)
        {
            double boundary = Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (long i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}
