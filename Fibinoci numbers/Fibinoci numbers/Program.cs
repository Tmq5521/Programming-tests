using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fibinoci_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Fib series";

            FileStream fs = new FileStream(@"../../nums.txt", FileMode.Create, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.AutoFlush = true;

            double[] I = new double[2] { 1, 1};
            sw.WriteLine(1);
            sw.WriteLine(1);

            while (I[I.Length - 1] <= Double.MaxValue)
            {
                Array.Resize<double>(ref I, I.Length + 1);
                I[I.Length - 1] = I[I.Length - 2] + I[I.Length - 3];
                sw.WriteLine(I[I.Length - 1]);
                Console.WriteLine(I[I.Length - 1]);
            }
        }
    }
}
