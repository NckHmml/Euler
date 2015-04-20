using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler015
    {
        public static string Run()
        {
            return LaticePath(20, 20).ToString(); 
        }

        private static double LaticePath(long a, long b)
        {
            double sum = 0;
            for (long i = 0; i < a; i++)
                sum += Math.Log10(a + b - i) - Math.Log10(i + 1);
            return Math.Pow(10, sum);
        }
    }
}
