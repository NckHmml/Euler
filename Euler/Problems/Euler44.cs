using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler44
    {
        public static string Run()
        {
            for (int i = 1; i < 1e6; i++)
            {
                int p = CalcPenta(i);
                for (int x = i - 1; x > i / 2; x--)
                {
                    int k = CalcPenta(x);
                    if (IsPenta(p - k))
                    {
                        int j = p - k;
                        if (IsPenta(k - j))
                            return (k - j).ToString();
                    }
                }
            }
            return "";
        }

        public static int CalcPenta(int n)
        {
            return (n * (3 * n - 1)) / 2;
        }

        public static bool IsPenta(int x)
        {
            int mult = 24 * x + 1;
            int root = (int)Math.Sqrt(mult);
            return root * root == mult && root % 6 == 5;
        }
    }
}
