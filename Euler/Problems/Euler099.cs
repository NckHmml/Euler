using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler099
    {
        public static string Run()
        {
            IEnumerable<string[]> vals = File.ReadAllLines("p099_base_exp.txt")
                .Select(x => x.Split(','));
            int i = 1;
            int result = 0;
            double max = 0;
            foreach (var val in vals)
            {
                double cur = int.Parse(val[1]) * Math.Log(int.Parse(val[0]));
                if (cur > max)
                {
                    result = i;
                    max = cur;
                }
                i++;
            }
            return result.ToString();
        }
    }
}
