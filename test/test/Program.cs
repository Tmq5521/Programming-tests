using System;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = new System.Diagnostics.Stopwatch();
            timer.Start();

            int i = 1;
            while (i != 0)
            {
                i += 1;
            }
            timer.Stop();
            Console.WriteLine(timer.Elapsed);
            Console.ReadKey();
        }
    }
}
