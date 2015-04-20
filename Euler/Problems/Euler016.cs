using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler016
    {
        public static string Run()
        {
            return BigInteger
                .Pow(2, 1000)
                .ToString()
                .Sum(x => x - 0x30)
                .ToString();
        }
    }
}
