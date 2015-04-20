using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler025
    {
        public static string Run()
        {
            BigInteger 
                max = BigInteger.Pow(10, 999),
                fib = 0,
                fib2 = 1,
                fib1 = 1;
            int i = 2;
            while (fib < max)
            {
                fib = fib1 + fib2;
                fib2 = fib1;
                fib1 = fib;
                i++;
            }
            return i.ToString();
        }
    }
}
