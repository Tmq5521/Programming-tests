using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tone_generator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int[] Num = { 0, 0};
                Console.WriteLine("Frequency (Hz) ?");
                string Freq = Console.ReadLine();
                Num[0] = int.Parse(Freq + "0")/10;
                Console.WriteLine("Duration (S) ?");
                string Dura = Console.ReadLine();
                Num[1] = int.Parse(Dura + "0")*100;
                if (Num[1] > 37 && Num[1] < 32000)
                {
                    Console.Beep(Num[0], Num[1]);
                }
                else
                {
                    Console.WriteLine("Error: Frequency has to be greater than 37 and less than 32000 Hz.");
                }
            }
        }
    }
}
