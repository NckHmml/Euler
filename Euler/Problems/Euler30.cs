using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler30
    {
        public static string Run()
        {
            const int pow = 5;
            int max = (int)Math.Pow(9, pow) * (pow + 1);
            int
                sum,
                number,
                temp,
                answer = 0;
            for (int i = 2; i < max; i++)
            {
                number = i;
                sum = 0;
                while (number > 0)
                {
                    temp = number % 10;
                    number -= temp;
                    number /= 10;
                    sum += (int)Math.Pow(temp, pow);
                    if (sum > i)
                        break;
                }
                if (i == sum)
                    answer += sum;
            }
            return answer.ToString();
        }
    }
}
