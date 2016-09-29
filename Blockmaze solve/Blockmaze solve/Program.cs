using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blockmaze_solve
{
    class Program
    {
        //variables
        int time;
        string chars = "#.SEB";

        //functions
        int[][] readFile()
        {
            string[] strings = System.IO.File.ReadAllLines(@"..\in");
            int[][] map = new int;
            for (int x = 0; 0 < strings.Length; x++)
            {
                if (strings[x].Contains("//"))
                {
                    time = int.Parse(strings[x].Remove(0, 2));
                }
                else if(strings[x][0] == '#')
                {
                    for (int y = 0; 0 < strings[x].Length; y++)
                    {
                        map[x][y] = chars.LastIndexOf(strings[x][y]);
                    }
                }
            }
            return map;
        }
        static void Main(string[] args)
        {

        }
    }
}
