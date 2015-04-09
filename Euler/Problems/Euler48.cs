using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler48
    {
        public static string Run()
        {
            BigInteger value = 0;
            const long mod = (long)1e10;
            for (int i = 1; i <= 1000; i++)
                value += BigInteger.ModPow(i, i, mod);
            value %= mod;
            return value.ToString();
        }
    }
}
