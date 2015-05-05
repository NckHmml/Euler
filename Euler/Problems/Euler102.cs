using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler102
    {
        public static string Run()
        {            
            return File.ReadAllLines("p102_triangles.txt")
                .Select(x => ParseTriangles(x))
                .Count(x => ContainsOrigin(x.ToArray()))
                .ToString();
        }

        private static IEnumerable<Point<int>> ParseTriangles(string triangle)
        {
            string[] splits = triangle.Split(',');
            for (int i = 0; i < splits.Length; i += 2)
            {
                int left = Int32.Parse(splits[i]);
                int right = Int32.Parse(splits[i + 1]);
                yield return new Point<int> { x = left, y = right };
            }
        }

        private static bool ContainsOrigin(Point<int>[] points)
        {
            var origin = new Point<int> { x = 0, y = 0 };
            bool b1, b2, b3;

            b1 = Sign(origin, points[0], points[1]);
            b2 = Sign(origin, points[1], points[2]);
            b3 = Sign(origin, points[2], points[0]);

            return ((b1 == b2) && (b2 == b3));
        }

        private static bool Sign(params Point<int>[] points)
        {
            return (points[0].x - points[2].x) * (points[1].y - points[2].y) - (points[1].x - points[2].x) * (points[0].y - points[2].y) < 0;
        }

        private struct Point<T>
        {
            public T x;
            public T y;
        }
    }
}
