using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler28
    {
        public static string Run()
        {
            int 
                start,
                answer = 1;
            for (int i = 3; i <= 1001; i += 2)
            {
                start = i * i;
                answer += start;
                for (int x = 1; x < 4; x++)
                {
                    start -= i - 1;
                    answer += start;
                }
            }
            return answer.ToString();
        }
    }
}
