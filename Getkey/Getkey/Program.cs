using System;

namespace Getkey
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Get Key";
            while (true)
                Console.WriteLine(" | " + Console.ReadKey().Key);
        }
    }
}