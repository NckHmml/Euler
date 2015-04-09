using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler20
    {
        public static string Run()
        {
            int start = 100;
            BigInteger value = 100;
            while (start > 1)
                value *= --start;
            return value.ToString().Sum(x => x - 0x30).ToString();
        }
    }
}
