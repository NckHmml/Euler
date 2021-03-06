﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler004
    {
        public static string Run()
        {
            int max = 0;
            for (int x = 1000; x > 0; x--)
                for (int y = 1000; y > 0; y--)
                    if (x * y > max && IsPalindrome(x * y))
                        max = x * y;
            return max.ToString();
        }

        private static bool IsPalindrome(int n)
        {
            int num, rem, sum = 0, temp;
            num = n;
            temp = num;
            while (Convert.ToBoolean(num))
            {
                rem = num % 10;
                num = num / 10;
                sum = sum * 10 + rem;
            }
            return temp == sum;
        }
    }
}
