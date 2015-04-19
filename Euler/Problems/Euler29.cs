using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler29
    {
        public static string Run()
        {
            int count = 0;
            var cache = new HashSet<double>();
            for (int a = 2; a <= 100; a++ )
            {
                for (int b = 2; b <= 100; b++)
                {
                    double val = Math.Pow(a, b);
                    if (!cache.Contains(val))
                    {
                        cache.Add(val);
                        count++;
                    }
                }
            }
            return count.ToString();
        }
    }
}
