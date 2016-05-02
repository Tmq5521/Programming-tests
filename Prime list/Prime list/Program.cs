using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prime_list
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Prime finder";

            FileStream fs = new FileStream(@"../../list.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.AutoFlush = true;
            sw.WriteLine(1);

            double[] nums = new double[1];
            int index = 0;
            double i = 2;
            bool prime;

            Console.WriteLine("How many Primes?");
            int amount = int.Parse(Console.ReadLine());
            while (amount >= nums.Length + 2)
            {
                prime = true;
                if (index <= 11)
                { 
                    for (double v = 2; v < i; v++)
                    {
                        if (i % v == 0)
                            prime = false;
                    }
                }
                else
                {
                    foreach (double num in nums)
                    {
                        if (i % num == 0)
                            prime = false;
                    }
                }
                if (prime)
                {
                    index = index + 1;
                    sw.WriteLine(i);
                    Console.WriteLine(i);
                    Array.Resize<double>(ref nums, index);
                    nums[index - 1] = i;
                }
                i = i + 1;
            }
            Console.WriteLine("Done!");
            Console.ReadKey();
        }
    }
}
