using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_functions_lib
{
    public class text // text lib
    {
        static void WordWrap (string str)
        {
            string[] Str = str.Split(' '); // split words
            foreach (string word in Str) // run throught the words
            {
                int space = Console.BufferWidth - Console.CursorLeft; // find remaining space
                if (word.Length < space) // see if fits 
                {
                    Console.Write(word + ' '); // add word + space
                }
                else
                {
                    Console.SetCursorPosition(0, Console.CursorTop + 1); // advance line
                    Console.Write(word + ' '); // add word + space
                }

            }
            if (Console.CursorTop < Console.WindowHeight - 2)
                Console.SetCursorPosition(0, Console.CursorTop + 1); // advance a line
            else
            {
                Console.SetCursorPosition(0, Console.CursorTop + 1); // advance a line
                Console.Write("Press a key to continue.");
                Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 0);
            }
        }
        static void Log (string @Type, string @String, System.IO.StreamWriter Stream)
        {
            string @type = @Type.Remove(9, Type.Length - 8);
            Stream.WriteLine(DateTime.Now + "|" + @type + "|" + @String);
        }
    }
}
