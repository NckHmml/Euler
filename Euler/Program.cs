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
            problems.Add(001, () => Euler001.Run());
            problems.Add(002, () => Euler002.Run());
            problems.Add(003, () => Euler003.Run());
            problems.Add(004, () => Euler004.Run());
            problems.Add(005, () => Euler005.Run());
            problems.Add(006, () => Euler006.Run());
            problems.Add(008, () => Euler008.Run());
            problems.Add(009, () => Euler009.Run());
            problems.Add(014, () => Euler014.Run());
            problems.Add(015, () => Euler015.Run());
            problems.Add(016, () => Euler016.Run());
            problems.Add(017, () => Euler017.Run());
            problems.Add(018, () => Euler018.Run());
            problems.Add(019, () => Euler019.Run());
            problems.Add(020, () => Euler020.Run());
            problems.Add(022, () => Euler022.Run());
            problems.Add(025, () => Euler025.Run());
            problems.Add(026, () => Euler026.Run());
            problems.Add(028, () => Euler028.Run());
            problems.Add(029, () => Euler029.Run());
            problems.Add(030, () => Euler030.Run());
            problems.Add(036, () => Euler036.Run());
            problems.Add(042, () => Euler042.Run());
            problems.Add(044, () => Euler044.Run());
            problems.Add(045, () => Euler045.Run());
            problems.Add(048, () => Euler048.Run());
            problems.Add(052, () => Euler052.Run());
            problems.Add(053, () => Euler053.Run());
            problems.Add(059, () => Euler059.Run());
            problems.Add(067, () => Euler067.Run());
            problems.Add(079, () => Euler079.Run());
            problems.Add(096, () => Euler096.Run());
            problems.Add(097, () => Euler097.Run());
            problems.Add(099, () => Euler099.Run());

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
