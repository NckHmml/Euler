using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler053
    {
        public static string Run()
        {
            int count = 0;
            for (int n = 1; n <= 100; n++)
            {
                for (int k = n - 1; k > 0; k--)
                {
                    if (Binomial(n, k) > 1e6)
                        count++;
                }
            }
            return count.ToString();
        }

        private static double Binomial(int n, int k)
        {
            double sum = 0;
            for (int i = 0; i < k; i++)
                sum += Math.Log10(n - i) - Math.Log10(i + 1);
            return Math.Pow(10, sum);
        }
    }
}
