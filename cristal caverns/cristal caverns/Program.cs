// day 1 2 hours
// day 2 2:15 hours



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
        public string discribe; // strings containing discription of the room
        public string[] exits; //strings containing discriptions of the exits
        public string[][,,] paths ; //array containing the path each exit takes

        public cavern(sbyte[] pos, string discribe, string[] exits, string[][,,] paths )
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
        static object[,,] Map1 = new object[100,100,100];

        static void Load() // loads map from file
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "save.txt"); // stores current directory in path
            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains("Cavern:")) // finds all cavern defs from file
                {
                    byte B = 0;
                    sbyte[] C;
                    C = new sbyte[3];
                    string T = line.Substring(8); // looses the "Cavern:" part of the string
                    int i = 0;
                    for (int I = 1; I < T.Length; I++) // iterates through the line
                    {
                        if (T[I] == ","[0]) // finds commas
                        {

                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test);
                            Console.WriteLine("{0}", i);
                            C[B] = sbyte.Parse(test); //pointer

                            i = I + 1;
                            B++;
                        }
                    }

                    string[] E; // test junk
                    string[][,,] D;
                    E = new string[6];
                    D = new string[6][,,]; // ...

                    cavern Cavern = new cavern(C, "", E, D); //make new room

                    Map1[ C[0], C[1], C[2]] = Cavern; // store into a array

                }
            }
        }

        static void Main(string[] args)
        {
            Load();
            for(byte x = 0; x < 100; x++)
            {
                for(byte y = 0; y < 100; y++)
                {
                    for(byte z = 0; z < 100; z++)
                    {
                        if (Map1[x, y, z] != null)
                        {
                            Console.WriteLine(Map1[x, y, z]);
                        }
                    }
                }
            }
            Console.ReadKey(); // pause...
        }
    }
}
