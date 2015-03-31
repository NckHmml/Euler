using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler22
    {
        public static string Run()
        {
            string[] nameBuffer;

            using (FileStream file = File.OpenRead("p022_names.txt"))
            {
                byte[] charbuffer = new byte[file.Length];
                file.Read(charbuffer, 0, (int)file.Length);
                nameBuffer = Encoding.ASCII.GetString(charbuffer).Replace("\"", "").Split(',');
            }

            double sum = nameBuffer
                .OrderBy(x => x)
                .Select((v, i) => new { v, i })
                .Sum(x => (x.i + 1) * GetNameWorth(x.v));

            return sum.ToString();
        }

        private static int GetNameWorth(string name)
        {
            int sum = 0;
            foreach (char cName in name)
                sum += (byte)cName - 0x40;
            return sum;
        }
    }
}
