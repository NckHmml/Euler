using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler097
    {
        public static string Run()
        {
            const long mod = (long)1e10;
            BigInteger val = BigInteger.ModPow(2, 7830457, mod);
            val = BigInteger.Multiply(val, 28433) % mod;
            return (++val).ToString();
        }
    }
}
