using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler79
    {
        public static string Run()
        {
            string[] passcodes = File.ReadAllLines("p079_keylog.txt");
            List<List<byte>> buffer = passcodes
                .Select(x => x.ToArray()
                    .Select(y => byte.Parse(y.ToString()))
                    .ToList())
                .ToList();

            var answer = new StringBuilder();
            while (buffer.Any(x => x.Any()))
            {
                for (byte num = 0; num < 10; num++)
                {
                    bool isLeft = buffer.Any(x => x.Any(y => y == num));
                    if (!isLeft) continue;
                    for (int i = 0; i < buffer.Count; i++)
                    {
                        if (buffer[i].Any(x => x == num))
                            isLeft &= buffer[i][0] == num;
                    }
                    if (isLeft)
                    {
                        answer.Append(num);
                        for (int i = 0; i < buffer.Count; i++)
                            buffer[i].Remove(num);
                    }
                }
            }
            return answer.ToString();
        }
    }
}
