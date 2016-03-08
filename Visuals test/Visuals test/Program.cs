using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Visuals_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Art Test";
            Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            List<string> Doc = new List<string>();
            string path = Path.GetFullPath(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "../../", "picture.txt")); // stores current directory in path
            foreach (string line in File.ReadLines(path))
            {
                Doc.Add(line);
            }
            for(int x = 0; x < Doc.Count && x < Console.LargestWindowHeight; x++)
            {
                for(int y = 0; y < Doc[x].Length && y < Console.LargestWindowWidth; y++)
                {
                    Console.SetCursorPosition(y, x);
                    Console.Write(Doc[x][y]);
                }
            }

           Console.ReadKey();
        }
    }
}
