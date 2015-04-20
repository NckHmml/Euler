using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler001
    {
        public static string Run()
        {
            int sum = 0;
            for (int i = 0; i < 1e3; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            return sum.ToString();
        }
    }
}
