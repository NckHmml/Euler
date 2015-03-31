using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler52
    {
        public static string Run()
        {
            int start = 6;
            bool found;
            for (int i = start; i < Int32.MaxValue; i++)
            {
                found = true;
                for (int x = start; x > 0; x--)
                {
                    found &= i.ToString()
                        .OrderBy(c => c)
                        .SequenceEqual(
                            (i * x)
                            .ToString()
                            .OrderBy(c => c));

                    if (!found)
                        break;
                }
                if (found)
                    return i.ToString();
            }
            return "";
        }
    }
}
