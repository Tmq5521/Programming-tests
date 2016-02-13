using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace cristal_caverns
{
    class cavern //object template for each room
    {
        public sbyte[] pos; // position in array
        public string discribe, exits; //strings containing discriptions of the rooms and exits
        public string[][,,] paths ; //array containing the path each exit takes

        public cavern(sbyte[] pos, string discribe, string exits, string[][,,] paths )
        {
            // sets variables in the new object
            this.pos = pos;
            this.discribe = discribe;
            this.exits = exits;
            this.paths = paths;
        }

        // Return the point's value as a string.
        public override String ToString()
        {
            return string.Format("({0}, {1}, {2})", pos[0], pos[1] ,pos[2]);
        }

        // Return a copy of this point object by making a simple field copy.
        public cavern Copy()
        {
            return (cavern)this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Load() // loads map from file
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "save.txt"); // stores current directory in path
            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains("Cavern:")) // finds all cavern defs from file
                {
                    string temp = line.Substring(8); // looses the "Cavern:" part of the string
                    int i = 8; 
                    for (int I = 1; I <= temp.Length; I++) // iterates through the line
                    {
                        if (temp[I] == ","[0] ) // finds commas
                        {
                            string test = (temp.Substring(i, (i - I)));
                            int.Parse(test); //pointer
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Load();
            Console.ReadKey(); // pause...
        }
    }
}
