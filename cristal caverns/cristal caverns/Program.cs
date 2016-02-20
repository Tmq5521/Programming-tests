// day 1 2 hours
// day 2 2:15 + 1:30 hours
// day 3 0:30 hours


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
        public int[][] paths ; //array containing the path each exit takes

        public cavern(sbyte[] pos, string discribe, string[] exits, int[][] paths )
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
            return string.Format("({0}, {1}, {2}) ({3}) ({4})", pos[0], pos[1] ,pos[2], discribe, exits[0]);
            //string[] Text = {discribe, exits};
            //return string.Format(Text);
        }
        
        

        // Return a copy of this point object by making a simple field copy.
        public cavern Copy()
        {
            return (cavern)this.MemberwiseClone();
        }
    }
    class Program
    {
        static object[,,] Map1 = new object[100000000,100000000,100000000];

        static void Load() // loads map from file
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "save.txt"); // stores current directory in path
            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains("Cavern:")) // finds all cavern defs from file
                {
                    int c = 0;
                    int e = 0;
                    int d = 0;

                    sbyte[] C;
                    C = new sbyte[3];

                    string[] E = new string[6];
                    int[][] D = new int[5][]; // ...
                    string F ;

                    string T = line.Substring(8); // looses the "Cavern:" part of the string
                    int i = 0;
                    for (int I = 1; I < T.Length; I++) // iterates through the line
                    {
                        if (T[I] == "<"[0]) // finds <
                        {

                            
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            C[c] = sbyte.Parse(test); // pulls numerical value followed by a <

                            i = I + 1; //Advances start pointer
                            c++;
                        }
                        if (T[I] == ";"[0]) // finds ;
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            F = test; // pulls string value followed by a ;

                            i = I + 1; //Advances start pointer
                        }
                        if (T[I] == ":"[0]) // finds :
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            E[e] = test; // pulls string value followed by a :

                            i = I + 1; //Advances start pointer
                            e++;
                        }
                        if (T[I] == ">"[0]) // finds >
                        {
                            int Start = 0;
                            int pointer = 0;
                            int[] Delta = new int [2];
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            for(int End = 1; End < test.Length; End++)
                            {
                                if (T[End] == "|"[0]) // finds |
                                {
                                    string testSub = (T.Substring(Start, (End - Start)));
                                    Console.WriteLine(testSub); //Debug
                                    Console.WriteLine("{0},{1}", End, Start); //Debug
                                    Delta[pointer]= sbyte.Parse(testSub); // pulls string value followed by a |

                                    Start = End + 1; //Advances start pointer
                                    pointer++;
                                }
                            }
                            D[d] = Delta; // pulls string value followed by a >

                            i = I + 1; //Advances start pointer
                            d++;
                        }

                    }

                    cavern Cavern = new cavern(C, F, E, D); //make new room

                    Map1[ C[0], C[1], C[2]] = Cavern; // store into a array

                }
            }
        }
        
        static void debugCheck() {
            for(byte x = 0; x < 100000000; x++)
            {
                for(byte y = 0; y < 100000000; y++)
                {
                    for(byte z = 0; z < 100000000; z++)
                    {
                        if (Map1[x, y, z] != null)
                        {
                            object current = Map1[x, y, z];
                            Console.WriteLine(current.pos);
                            Console.WriteLine(current.discribe);
                            for (byte w = 0; w < current.exits.length; w++) 
                            {
                                Console.WriteLine(current.exits[w]);
                            }
                        }
                    }
                }
            }
        }
        
        static void Main(string[] args)
        {
            Load();
            debugCheck(); // Debug!
            Console.ReadKey(); // pause...
        }
    }
}
