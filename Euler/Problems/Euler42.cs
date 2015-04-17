using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler42
    {
        public static string Run()
        {
            IEnumerable<int> wordValues = File.ReadAllText("p042_words.txt")
                .Replace("\"", "")
                .Split(',')
                .Select(x => GetWorth(x));
            return wordValues.Count(x => IsTri(x)).ToString();
        }

        private static bool IsTri(int x)
        {
            int mult = 8 * x + 1;
            int root = (int)Math.Sqrt(mult);
            return root * root == mult;
        }

        private static int GetWorth(string word)
        {
            int sum = 0;
            foreach (char c in word)
                sum += c - 0x40;
            return sum;
        }
    }
}
