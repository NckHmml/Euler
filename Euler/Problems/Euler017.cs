using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler017
    {
        public static string Run()
        {
            int sum = 0;
            for (int i = 999; i >= 1; i--)
                sum += GetNumberLength(i);
            sum += 11; //one thousand
            return sum.ToString();
        }

        public static int GetNumberLength(int i)
        {
            // for 100-999
            for (int x = 900; x >= 100; x -= 100)
            {                
                if ((i % x) != i)
                {
                    int hundreds = (i - (i % x)) / 100;
                    hundreds = GetNumberLength(hundreds) + 7;
                    if (i % x == 0)
                        return hundreds;
                    else
                        return GetNumberLength(i % x) + hundreds + 3;
                }
            }

            // for 20-99
            var curbuffer = new Dictionary<int, int>()
            {
                { 20, 6 },
                { 30, 6 },
                { 40, 5 },
                { 50, 5 },
                { 60, 5 },
                { 70, 7 },
                { 80, 6 },
                { 90, 6 },
            };
            for (int x = 90; x >= 20; x -= 10)
            {
                if ((i % x) != i)
                    return GetNumberLength(i - x) + curbuffer[x];
            }

            // for 14-19
            for (int x = 19; x >= 14; x--)
            {
                if (i == 15 || i == 18)
                    return GetNumberLength(i - 10) + 3;
                if ((i % x) != i)
                    return GetNumberLength(i - 10) + 4;
            }

            // for 10-13
            curbuffer = new Dictionary<int, int>()
            {
                { 10, 3 },
                { 11, 6 },
                { 12, 6 },
                { 13, 8 },
            };
            for (int x = 13; x >= 10; x--)
            {
                if ((i % x) != i)
                    return curbuffer[x];
            }

            // for 1-9
            curbuffer = new Dictionary<int, int>()
            {
                { 1, 3 },
                { 2, 3 },
                { 3, 5 },
                { 4, 4 },
                { 5, 4 },
                { 6, 3 },
                { 7, 5 },
                { 8, 5 },
                { 9, 4 },
            };
            for (int x = 9; x >= 1; x--)
            {
                if ((i % x) != i)
                    return curbuffer[x];
            }
            return 0;
        }
    }
}
