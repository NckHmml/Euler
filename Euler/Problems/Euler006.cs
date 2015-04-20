using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler006
    {
        public static string Run()
        {
            int max = 100,
                powsum = ((max * (max + 1) * (2 * max + 1)) / 6), // n(n+1)(2n+1) / 6
                sumpow = (max * (max + 1)) / 2; //n(n+1) / 2
            sumpow *= sumpow;
            return (sumpow - powsum).ToString();
        }
    }
}
