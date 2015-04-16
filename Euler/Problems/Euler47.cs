using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler47
    {
        public static string Run()
        {
            double cur;
            const int start = 165;
            for (int i = start + 1; i < 1e6; i++)
            {
                cur = CalcPenta(i);
                if (CalcInvHexa(cur) == (int)CalcInvHexa(cur))
                    return cur.ToString();
            }
            return "Not found!";
        }

        public static double CalcTri(double n)
        {
            return (n * (n + 1)) / 2d;
        }

        public static double CalcInvTri(double n)
        {
            return (1 / 2d) * (-1 + Math.Sqrt(8 * n + 1));
        }

        public static double CalcPenta(double n)
        {
            return (n * (3 * n - 1)) / 2d;
        }

        public static double CalcInvPenta(double n)
        {
            return (1 / 6d) * (1 + Math.Sqrt(24 * n - 1));
        }

        public static double CalcHexa(double n)
        {
            return n * (2 * n - 1);
        }

        public static double CalcInvHexa(double n)
        {
            return (1 / 4d) * (1 + Math.Sqrt(8 * n + 1));
        }
    }
}
