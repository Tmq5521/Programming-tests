using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFL
{
    public class Text
    {
        public static void WordWrap (string str)
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
        public static void Log (string @Type, string @String, StreamWriter Stream)
        {
            if (@Type.Length < 9)
                @Type = @Type + "                   ";
            Stream.WriteLine(DateTime.Now + " |" + @Type.Substring(0,9) + "| " + @String);
        }
        public static void Art (string name, int sizeX)
        {
            string @pic = Path.Combine(@"pic/", name); // stores current directory in pic
            try
            {
                string[] file = File.ReadAllLines(@pic); // put the pic in an string array

                for (int y = 0; y < file.Length; y++) // go through the array
                {

                    Console.SetCursorPosition(0, y);
                    Console.Write(file[y]); // write line
                }
            }
            catch
            {

            }
        }
    }
}
