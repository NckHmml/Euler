using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler19
    {
        public static string Run()
        {
            DateTime start = new DateTime(1901, 01, 01);
            DateTime end = new DateTime(2000, 12, 31);
            int count = 0;
            while (start < end)
            {
                if (start.DayOfWeek == DayOfWeek.Sunday)
                    count++;
                start = start.AddMonths(1);
            }
            return count.ToString();
        }
    }
}
