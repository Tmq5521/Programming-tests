// day 1 2 hours
// day 2 2:15 + 1:30 hours
// day 3 0:30 hours
// day 4 1:15 hours

// Type exeption error ???

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
        public int[] pos { get; set; } // position in array
        public string discribe { get; set; } // strings containing discription of the room
        public string[] exits { get; set; } //strings containing discriptions of the exits
        public int[][] paths { get; set; } //array containing the path each exit takes
        public item[] inventory { get; set; } // array containing Items on the ground

        public cavern(int[] pos, string discribe, string[] exits, int[][] paths )
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
    
    class item //object template for Items
    {
        public string name; // Item Name
        public string discription; // Item Discription
        
        public item ( string name, string discription) // sets Variables
        {
            this.name = name;
            this.discription = discription;
        }
        
        public override String ToString() // overides the string value of this object
        {
            return string.Format( "{0}, {1}", name, discription);
        }
        
        public item Copy()
        {
            return (item)this.MemberwiseClone();
        }
    }
    
    class Program
    {
        static cavern[,,] Map1 { get; set; }  = new cavern[100000000, 100000000, 100000000];

        static void Load() // loads map from file
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "save.txt"); // stores current directory in path
            foreach (string line in File.ReadLines(path))
            {
                if (line.Contains("//")) // finds comments and reads them in debug
                {
                    Console.WriteLine(line); // debug comment reader
                }
                else if (line.Contains("Cavern:")) // finds all cavern defs from file
                {
                    int pos = 0;   // Pointers
                    int exits = 0; //
                    int route = 0; //

                    int[] Pos = new int[3];         // Arrays 
                    string[] Exits = new string[6]; //
                    int[][] Route = new int[5][];   // ...
                    
                    string Dis = ""; // String

                    string T = line.Substring(8); // looses the "Cavern:" part of the string
                    int i = 0;
                    for (int I = 1; I < T.Length; I++) // iterates through the line
                    {
                        if (T[I] == "<"[0]) // finds pos values apended with a < 
                        {

                            
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Pos[pos] = int.Parse(test); // pulls numerical value followed by a <

                            i = I + 1; //Advances start pointer
                            pos++;
                        }
                        else if (T[I] == ";"[0]) // finds Room discription values apended with a ;
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Dis = test; // pulls string value followed by a ;

                            i = I + 1; //Advances start pointer
                        }
                        else if (T[I] == ":"[0]) // finds Exit discription values apended with a :
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Exits[exits] = test; // pulls string value followed by a :

                            i = I + 1; //Advances start pointer
                            exits++;
                        }
                        else if (T[I] == ">"[0]) // finds route sets apended with a >
                        {
                            int Start = 0;
                            int pointer = 0;
                            int[] Delta = new int [2];
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            for(int End = 1; End < test.Length; End++)
                            {
                                if (T[End] == "|"[0]) // finds route values apended with a |
                                {
                                    string testSub = (T.Substring(Start, (End - Start)));
                                    Console.WriteLine(testSub); //Debug
                                    Console.WriteLine("{0},{1}", End, Start); //Debug
                                    Delta[pointer]= int.Parse(testSub); // pulls string value followed by a |

                                    Start = End + 1; //Advances start pointer
                                    pointer++;
                                }
                            }
                            Route[route] = Delta; // pulls string value followed by a >

                            i = I + 1; //Advances start pointer
                            route++;
                        }

                    }

                    Map1[Pos[0], Pos[1], Pos[2]] = new cavern(Pos, Dis, Exits, Route); //make new room and store into an array

                }
                else if (line.Contains("Item:"))
                {
                    int pos = 0; // pointer
                    int[] Pos = new int[3];
                    string Dis = "" ;  // string
                    string Name = "" ; // 
                    int Amount = 1;  // int
                    
                    string T = line.Substring(5); // looses the "Item:" part of the string
                    int i = 0; // start pointer
                    for (int I = 1; I < T.Length; I++) // iterates through the line
                    {
                        if (T[I] == "<"[0]) // finds pos values apended with a < 
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Pos[pos] = int.Parse(test); // pulls numerical value followed by a <

                            i = I + 1; //Advances start pointer
                            pos++;
                        }
                        else if (T[I] == ";"[0]) // finds Item name values apended with a ;
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Name = test; // pulls string value followed by a ;

                            i = I + 1; //Advances start pointer
                        }
                        else if (T[I] == ":"[0]) // finds Item discription values apended with a :
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Dis = test; // pulls string value followed by a :

                            i = I + 1; //Advances start pointer
                        }
                        else if (T[I] == "~"[0]) // finds Item discription values apended with a ~
                        {
                            string test = (T.Substring(i, (I - i)));
                            Console.WriteLine(test); //Debug
                            Console.WriteLine("{0},{1}", I, i); //Debug
                            Amount = int.Parse(test); // pulls string value followed by a ~

                            i = I + 1; //Advances start pointer
                        }
                    }
                    for (var I = 0; I < Amount; I++)
                    {
                        item Item = new item( Name, Dis); //build item
                        //int index = Map1[ Pos[0], Pos[1], Pos[2]].inventory.length; // find the dimintion of inventory
                        //Map1[ Pos[0], Pos[1], Pos[2]].inventory[index] = Item; // store into array
                    }
                }
                // outside if-else
            }
        }
        
        static void debugCheck() {
            for(int x = 0; x < 100000000; x++)
            {
                for (int y = 0; y < 100000000; y++)
                {
                    for (int z = 0; z < 100000000; z++)
                    {
                        if (Map1[x,y,z] != null)
                        {
                            cavern current = Map1[x, y, z];
                            Console.WriteLine(current.pos);
                            Console.WriteLine(current.discribe);
                            for (byte w = 0; w < 5; w++) 
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
