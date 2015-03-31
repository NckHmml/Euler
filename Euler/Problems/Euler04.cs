using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler04
    {
        public static string Run()
        {
            int max = 0;
            for (int x = 1000; x > 0; x--)
                for (int y = 1000; y > 0; y--)
                    if (x * y > max && IsPalindrome((x * y).ToString()))
                        max = x * y;
            return max.ToString();
        }

        private static bool IsPalindrome(string sTest)
        {
            return sTest.SequenceEqual(sTest.Reverse());
        }
    }
}
