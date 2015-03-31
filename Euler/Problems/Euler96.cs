using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    /// <remarks>
    /// https://github.com/NckHmml/SudokuSolver
    /// </remarks>
    public static class Euler96
    {
        private static char[] ValueChars = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        public static string Run()
        {
            string sudoku;
            using (FileStream file = File.OpenRead("p096.txt"))
            {
                byte[] charbuffer = new byte[file.Length];
                file.Read(charbuffer, 0, (int)file.Length);
                sudoku = Encoding.ASCII.GetString(charbuffer);
            }

            //int answer = SolveSudoku(sudoku
            //    .Replace("\r", "")
            //    .Split('\n')
            //    .Select((v, i) => i % 10 == 0 ? ":" : v)
            //    .Aggregate((a, b) => a + b)
            //    .Trim(':')
            //    .Split(':')
            //    .Select(x => x.ToCharArray())
            //    .ToArray()[1]);

            int answer = sudoku
                .Replace("\r", "")
                .Split('\n')
                .Select((v, i) => i % 10 == 0 ? ":" : v)
                .Aggregate((a, b) => a + b)
                .Trim(':')
                .Split(':')
                .Select(x => x.ToCharArray())
                .Sum(x => SolveSudoku(x));

            return answer.ToString();
        }

        private static int SolveSudoku(char[] sudoku)
        {
            char[,] blocks = GenerateBlocks(sudoku);
            StartBacktrack(blocks);
            string result = blocks[0, 0] + "" + blocks[1, 0] + "" + blocks[2, 0];
            return Int32.Parse(result);
        }

        public static void StartBacktrack(char[,] blocks)
        {
            bool[, ,] possibilities = Generatepossibilities(blocks);
            int count;
            do
            {
                IEnumerable<Spot> spots = GetSpots(possibilities);
                foreach (var spot in spots)
                    SetBlock(blocks, possibilities, spot.X, spot.Y, spot.V);

                count = spots.Count();
            } while (count > 0);

            if (IsSolved(blocks))
                return;

            Backtrack(blocks, possibilities);
        }

        public static bool Backtrack(char[,] blocks, bool[, ,] possibilities, int x = 0, int y = 0, int lastval = 0)
        {
            if (x == 8 && y == 8)
                return true;

            while (blocks[x, y] != '0')
            {
                if (++y >= 9)
                {
                    y = 0;
                    if (++x >= 9)
                        return true;
                }
            }
            int ty, tx;

            for (int val = 0; val < 9; val++)
            {
                if (possibilities[x, y, val])
                {
                    SetBlock(blocks, possibilities, x, y, val);
                    ty = y;
                    tx = x;
                    if (++ty >= 9)
                    {
                        ty = 0;
                        if (++tx >= 9)
                            return true;
                    }

                    if (Backtrack(blocks, possibilities, tx, ty, val))
                        return true;
                    else
                        ResetBlock(blocks, possibilities, x, y, val);
                }
            }

            if (--y < 0)
            {
                y = 8;
                x--;
            }
            return false;
        }

        public static void ResetBlock(char[,] blocks, bool[, ,] possibilities, int x, int y, int val)
        {
            char cur = ValueChars[val];
            blocks[x, y] = '0';
            // Rows
            for (var ix = 0; ix < 9; ix++)
            {
                if (!possibilities[ix, y, val])
                    possibilities[ix, y, val] =
                        SolveRow(blocks, ix, y, cur) &&
                        SolveColumn(blocks, ix, y, cur) &&
                        SolveCell(blocks, ix, y, cur);
            }

            // Columns
            for (var iy = 0; iy < 9; iy++)
            {
                if (!possibilities[x, iy, val])
                    possibilities[x, iy, val] =
                        SolveRow(blocks, x, iy, cur) &&
                        SolveColumn(blocks, x, iy, cur) &&
                        SolveCell(blocks, x, iy, cur);
            }

            // Cell
            var startx = x - (x % 3);
            var starty = y - (y % 3);

            for (var ix = startx; ix < startx + 3; ix++)
            {
                for (var iy = starty; iy < starty + 3; iy++)
                {
                    if (!possibilities[ix, iy, val])
                        possibilities[ix, iy, val] =
                            SolveRow(blocks, ix, iy, cur) &&
                            SolveColumn(blocks, ix, iy, cur) &&
                            SolveCell(blocks, ix, iy, cur);
                }
            }
        }

        public static void SetBlock(char[,] blocks, bool[, ,] possibilities, int x, int y, char val)
        {
            SetBlock(blocks, possibilities, x, y, Array.IndexOf<char>(ValueChars, val));
        }

        public static void SetBlock(char[,] blocks, bool[, ,] possibilities, int x, int y, int val)
        {
            blocks[x, y] = ValueChars[val];

            // Rows
            for (var ix = 0; ix < 9; ix++)
                possibilities[ix, y, val] = false;

            // Columns
            for (var iy = 0; iy < 9; iy++)
                possibilities[x, iy, val] = false;

            // Cell
            var startx = x - (x % 3);
            var starty = y - (y % 3);
            for (var ix = startx; ix < startx + 3; ix++)
            {
                for (var iy = starty; iy < starty + 3; iy++)
                    possibilities[ix, iy, val] = false;
            }
        }

        public static bool IsSolved(char[,] blocks)
        {
            return
                blocks[0, 0] != '0' &&
                blocks[1, 0] != '0' &&
                blocks[2, 0] != '0';
        }

        private static IEnumerable<Spot> GetSpots(bool[, ,] possibilities)
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    int
                        count = 0,
                        spot = 0;
                    for (int val = 0; val < 9; val++)
                    {
                        if (possibilities[x, y, val])
                        {
                            count++;
                            spot = val;
                        }
                    }
                    if (count == 1)
                        yield return new Spot { X = x, Y = y, V = ValueChars[spot] };
                }
            }
        }


        private struct Spot
        {
            public int X;
            public int Y;
            public char V;
        }

        private static char[,] GenerateBlocks(char[] sudoku)
        {
            char[,] ret = new char[9, 9];

            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    ret[x, y] = sudoku[x + (y * 9)];

            return ret;
        }
        private static bool[, ,] Generatepossibilities(char[,] blocks)
        {
            bool[, ,] ret = new bool[9, 9, 9];

            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    for (int val = 0; val < 9; val++)
                    {
                        bool possible = true;
                        possible &= blocks[x, y] == '0';
                        possible &= SolveRow(blocks, x, y, ValueChars[val]);
                        possible &= SolveColumn(blocks, x, y, ValueChars[val]);
                        possible &= SolveCell(blocks, x, y, ValueChars[val]);
                        ret[x, y, val] = possible;
                    }

            return ret;
        }

        private static bool SolveRow(char[,] blocks, int x, int y, char val)
        {
            for (var ix = 0; ix < 9; ix++)
            {
                if (x == ix) continue;
                if (blocks[ix, y] == val) return false;
            }
            return true;
        }

        private static bool SolveColumn(char[,] blocks, int x, int y, char val)
        {
            for (var iy = 0; iy < 9; iy++)
            {
                if (y == iy) continue;
                if (blocks[x, iy] == val) return false;
            }
            return true;
        }

        private static bool SolveCell(char[,] blocks, int x, int y, char val)
        {
            var startx = x - (x % 3);
            var starty = y - (y % 3);

            for (var ix = startx; ix < startx + 3; ix++)
            {
                for (var iy = starty; iy < starty + 3; iy++)
                {
                    if (y == iy && x == ix) continue;
                    if (blocks[ix, iy] == val) return false;
                }
            }
            return true;
        }
    }
}
