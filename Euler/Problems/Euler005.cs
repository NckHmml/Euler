using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler005
    {
        public static string Run()
        {
            int top = 20;
            string ret = String.Empty;
            bool isDiv;
            for (int i = 1; i * top < Int32.MaxValue; i++)
            {
                isDiv = true;
                for (int x = top; x > 1; x--)
                {
                    isDiv &= (i * top) % x == 0;
                    if (!isDiv)
                        break;
                }
                if (isDiv)
                {
                    ret = (i * top).ToString();
                    break;
                }
            }
            return ret;
        }
    }
}
