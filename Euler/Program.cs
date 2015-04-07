using Euler.Problems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Program
    {
        static void Main(string[] args)
        {
            var problems = new Dictionary<int, Func<string>>();
            problems.Add(01, () => Euler01.Run());
            problems.Add(02, () => Euler02.Run());
            problems.Add(03, () => Euler03.Run());
            problems.Add(04, () => Euler04.Run());
            problems.Add(05, () => Euler05.Run());
            problems.Add(06, () => Euler06.Run());
            problems.Add(14, () => Euler14.Run());
            problems.Add(15, () => Euler15.Run());
            problems.Add(18, () => Euler18.Run());
            problems.Add(19, () => Euler19.Run());
            problems.Add(22, () => Euler22.Run());
            problems.Add(52, () => Euler52.Run());
            problems.Add(67, () => Euler67.Run());
            problems.Add(79, () => Euler79.Run());
            problems.Add(96, () => Euler96.Run());

            bool running;
            int result;
            Console.WriteLine("Please type the number of the problem you want to execute.");
            do
            {
                running = Int32.TryParse(Console.ReadLine(), out result);
                Console.Clear();
                if (running)
                {
                    if (!problems.ContainsKey(result))
                    {
                        Console.WriteLine("Problem '{0}' not found, please try again with a different number", result);
                        continue;
                    }
                    string answer;
                    Stopwatch watch = Stopwatch.StartNew();
                    answer = problems[result].Invoke();
                    watch.Stop();

                    Console.WriteLine("Elapsed time: {0}ms", watch.ElapsedTicks / (Stopwatch.Frequency * 1e-3));
                    Console.WriteLine("Answer: {0}", answer);
                    Console.WriteLine();
                    Console.WriteLine("Problem has been succesfully displayed on screen.");
                    Console.WriteLine("Please type the number of the problem you want to execute.");
                }
            } while (running);
        }
    }
}
