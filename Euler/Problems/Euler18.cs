using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler18
    {
        public static string Run()
        {
            string[] triangle = File.ReadAllLines("p018.txt");

            int[][] buffer = triangle
                .Select(x => x.Split(' ')
                    .Select(v => int.Parse(v))
                    .ToArray())
                .ToArray();

            for (int i = buffer.Length - 1; i > 0; i--)
                for (int x = 0; x < buffer[i].Length - 1; x++)
                    buffer[i - 1][x] += Math.Max(buffer[i][x], buffer[i][x + 1]);

            //   3         3           3    23
            //  7 4       7  4       20 19     
            // 2 4 6    10 13 15
            //8 5 9 3
            return buffer[0][0].ToString();
        }
    }
}
