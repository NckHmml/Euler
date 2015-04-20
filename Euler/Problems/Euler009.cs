using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler009
    {
        public static string Run()
        {            
            for (int b = 0; b < 1000; b += 4)
            {
                for (int a = 0; a < 1000; a += 3)
                {
                    int c = 1000 - (a + b);
                    if (a * a + b * b == c * c) 
                        return (a * b * c).ToString();
                }
            }
            return "";
        }
    }
}
