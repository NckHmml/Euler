using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler02
    {
        public static string Run()
        {
            int 
                curFib,
                i = 0,
                sum = 0;

            do
            {
                curFib = FibBinet(++i);
                if (isEven(curFib))
                    sum += curFib;
            } while (curFib < 4e6);

            return sum.ToString();
        }

        private static int FibBinet(int n)
        {
            double sqrt5 = Math.Sqrt(5.0);
            double phi = (1 + sqrt5) / 2;
            return (int)((Math.Pow(phi, n + 1) - Math.Pow(1 - phi, n + 1)) / sqrt5);
        }

        private static bool isEven(this long i)
        {
            return (i & 1) == 0;
        }
    }
}
