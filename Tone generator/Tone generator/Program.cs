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
            Console.Title = "Tone Generator";
            while (true)
            {
                int[] Num = { 0, 0}; // default values

                Freq: // freq
                Console.WriteLine("Frequency (Hz) ?"); //Q
                string Freq = Console.ReadLine(); // Input
                try { Num[0] = int.Parse(Freq); } // Parse
                catch
                {
                    Console.WriteLine("Error invalid input. Range from 37 to 32000.");
                    goto Freq;
                }

                Dura: //duration
                Console.WriteLine("Duration (mS) ?"); //Q
                string Dura = Console.ReadLine(); // Input
                try { Num[1] = int.Parse(Dura); } // Parse
                catch
                {
                    Console.WriteLine("Error invalid input. Range from 0 to 2 trillion.");
                    goto Dura;
                }

                try { Console.Beep(Num[0], Num[1]); } // Beep
                catch { Console.WriteLine("invalid range."); }
                Console.WriteLine("Done");
                Console.WriteLine(" "); // clear space
            }
        }
    }
}
