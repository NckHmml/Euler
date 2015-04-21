using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler089
    {
        public static string Run()
        {
            return File.ReadAllLines("p089_roman.txt")
                .Sum(x => x.Length - GetNumeralLength(GetRomanValue(x)))
                .ToString();
        }

        private static int GetRomanValue(string roman)
        {
            List<int> buffer = new List<int>();
            int
                cur = 0,
                last = GetNumeralValue(roman[0]);
            buffer.Add(last);
            for (int i = 1; i < roman.Length; i++)
            {
                cur = GetNumeralValue(roman[i]);
                if (cur > last)
                    buffer[buffer.Count - 1] = cur - last;
                else
                    buffer.Add(cur);
                last = cur;
            }
            return buffer.Sum();
        }

        private static int GetNumeralValue(char numeral)
        {
            switch (numeral)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

        private static int GetNumeralLength(int value)
        {
            int ret = 0;

            int M = value - value % 1000;
            value -= M;
            M /= 1000;
            ret += M;

            // CM
            if (value >= 900)
            {
                value -= 900;
                ret += 2;
            }

            // D
            if (value >= 500)
            {
                value -= 500;
                ret++;
            }

            // CD
            if (value >= 400)
            {
                value -= 400;
                ret += 2;
            }

            int C = value - value % 100;
            value -= C;
            C /= 100;
            ret += C;

            // XC
            if (value >= 90)
            {
                value -= 90;
                ret += 2;
            }

            // L
            if (value >= 50)
            {
                value -= 50;
                ret++;
            }

            // XL
            if (value >= 40)
            {
                value -= 40;
                ret += 2;
            }

            int X = value - value % 10;
            value -= X;
            X /= 10;
            ret += X;

            // IX
            if (value >= 9)
            {
                value -= 9;
                ret += 2;
            }

            // V
            if (value >= 5)
            {
                value -= 5;
                ret++;
            }

            // IV
            if (value >= 4)
            {
                value -= 4;
                ret += 2;
            }

            // I
            ret += value;

            return ret;
        }
    }
}
