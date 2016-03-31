// day 1 2 hours
// day 2 2:15 + 1:30 hours
// day 3 0:30 hours
// day 4 1:15 hours
// day 5 1:15 hours
// day 6 3:30
// day 7 3:30
// day 8 3:30
// day 9 3:30
// day 10 3:30
// day 11 4 hours
// day 12 8 hours
// day 13 3 hours

// complie with CFL.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using CFL;


namespace cristal_caverns
{


    class Program
    {
        // Initalization of functions
        static void Load() // loads map from file
        {
            Text.Log("Path",@"\Save_template.txt",Debug); // print path
            foreach (string line in File.ReadLines(@"Save_template.txt")) // reads file at path
            {
                Text.Log("Line",line,Debug);
                if (line.Contains("//")) // finds comments and reads them in debug
                {
                    // Debug.WriteLine(DateTime.Now + " | Comment | " + line); // debug comment reader
                }
                else if (line.Contains("Cavern:")) // finds all cavern defs from file
                {
                    int pos = 0;   // Pointers
                    int exits = 0; //
                    int route = 0; //

                    int[] Pos = new int[3];         // Arrays 
                    string[] Exits = new string[6]; //
                    int[,] Route = new int[6, 3];   // ...

                    string Dis = ""; // String
                    string @Pic = "404.txt";

                    string T = line.Substring(8); // looses the "Cavern:" part of the string
                    int i = 0;
                    for (int I = 1; I < T.Length; I++) // iterates through the line
                    {
                        if (T[I] == '<') // finds pos values apended with a < 
                        {


                            string test = (T.Substring(i, (I - i)));
                            Text.Log("Pos", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Pos[pos] = int.Parse(test); // pulls numerical value followed by a <

                            i = I + 1; //Advances start pointer
                            pos++;
                        }
                        else if (T[I] == ';') // finds Room discription values apended with a ;
                        {
                            string test = (T.Substring(i, (I - i)));
                            if (test[0] == ' ')
                            {
                                test = test.Substring(1, test.Length - 1);
                            }
                            Text.Log("Discription", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Dis = test; // pulls string value followed by a ;

                            i = I + 1; //Advances start pointer
                        }
                        else if (T[I] == ':') // finds Exit discription values apended with a :
                        {
                            string test = (T.Substring(i, (I - i)));
                            if (test[0] == ' ')
                            {
                                test = test.Substring(1, test.Length - 1);
                            }
                            Text.Log("Exit", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Exits[exits] = test; // pulls string value followed by a :

                            i = I + 1; //Advances start pointer
                            exits++;
                        }
                        else if (T[I] == '>') // finds route sets apended with a >
                        {
                            int Start = 0;
                            int pointer = 0;
                            int[] Delta = new int[2];
                            string test = (T.Substring(i, (I - i)));
                            Text.Log("Route", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            for (int End = 0; End < test.Length; End++)
                            {
                                if (test[End] == '|') // finds route values apended with a |
                                {
                                    string testSub = (test.Substring(Start, ((End) - Start)));
                                    Text.Log("Route[]", testSub, Debug);//Debug
                                    Text.Log("Pointer", End + "," + Start, Debug); //Debug //Debug
                                    Route[route, pointer] = int.Parse(testSub); // pulls string value followed by a |

                                    Start = End + 1; //Advances start pointer
                                    pointer++;
                                }
                            }
                            i = I + 1; //Advances start pointer
                            route++;
                        }
                        else if (T[I] == '^')
                        {
                            string test = (T.Substring(i, (I - i)));
                            if (test[0] == ' ')
                            {
                                test = test.Substring(1, test.Length - 1);
                            }
                            Text.Log("Exit", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            @Pic = test; // pulls string value followed by a :

                            i = I + 1; //Advances start pointer
                        }

                    }

                    Map1[Pos[0], Pos[1], Pos[2]] = new cavern(Pos, Dis, Exits, Route, @Pic); //make new room and store into an array

                }
                else if (line.Contains("Item:"))
                {
                    int pos = 0;      // pointer
                    int[] Pos = new int[3];
                    string Dis = "";  // string
                    string Name = ""; // 
                    int Amount = 1;   // int
                    bool Move = false;

                    string T = line.Substring(5); // looses the "Item:" part of the string
                    int i = 0; // start pointer
                    for (int I = 1; I < T.Length; I++) // iterates through the line
                    {
                        if (T[I] == '<') // finds pos values apended with a < 
                        {
                            string test = (T.Substring(i, (I - i)));
                            Text.Log("Pos", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Pos[pos] = int.Parse(test); // pulls numerical value followed by a <

                            i = I + 1; //Advances start pointer
                            pos++;
                        }
                        else if (T[I] == ';') // finds Item name values apended with a ;
                        {
                            string test = (T.Substring(i, (I - i)));
                            if (test[0] == ' ')
                            {
                                test = test.Substring(1, test.Length - 1);
                            }
                            Text.Log("Name", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Name = test; // pulls string value followed by a ;

                            i = I + 1; //Advances start pointer
                        }
                        else if (T[I] == ':') // finds Item discription values apended with a :
                        {
                            string test = (T.Substring(i, (I - i)));
                            if (test[0] == ' ')
                            {
                                test = test.Substring(1, test.Length - 1);
                            }
                            Text.Log("Discription", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Dis = test; // pulls string value followed by a :

                            i = I + 1; //Advances start pointer
                        }
                        else if (T[I] == '~') // finds Item amount values apended with a ~
                        {
                            string test = (T.Substring(i, (I - i)));
                            Text.Log("Amount", test, Debug);//Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Amount = int.Parse(test); // pulls string value followed by a ~

                            i = I + 1; //Advances start pointer
                        }
                        if (T[I] == '|') // finds Movable values apended with a |
                        {
                            string test = (T.Substring(i, (I - i)));
                            Text.Log("Movable",test,Debug); //Debug
                            Text.Log("Pointer", I + "," + i, Debug); //Debug
                            Move = bool.Parse(test); // pulls string value followed by a |

                            i = I + 1; //Advances start pointer
                        }
                    }

                    int max = Map1[Pos[0], Pos[1], Pos[2]].inventory.GetLength(0); // finds the max inventory size
                    item[] inventory = Map1[Pos[0], Pos[1], Pos[2]].inventory; // sets inventory as a local variable for simplicity

                    for (var I = 0; I < Amount; I++) // adds one itm to the frst null entry in the inventory
                    {
                        for (int index = 0; index < max; index++) // finds first null entry
                        {
                            if (inventory[index] == null) // null entry
                            {
                                inventory[index] = new item(Name, Dis, Move);
                                break;
                            }
                            else if (inventory[index].equals()) // empty entry
                            {
                                inventory[index] = new item(Name, Dis, Move);
                                break;
                            }

                        }
                    }
                    Map1[Pos[0], Pos[1], Pos[2]].inventory = inventory; // dump the resulting local inventory into the cavern inventory
                }
                // outside if-else for file read
            }
        }
        // More functions
        static void debugCheck(int x, int y, int z)
        {

            if (Map1[x, y, z] != null) // safety
            {
                cavern current = Map1[x, y, z]; // set local var current to cavern
                Text.Log("Cavern", String.Format("{0},{1},{2}",current.pos[0], current.pos[1], current.pos[2]), Debug); // debug pos
                Text.Log("Discription",current.discribe,Debug); // debug discription
                for (byte w = 0; w < 6; w++) // exit iterator
                {
                    Text.Log("exit",string.Format("{0} |", w) + current.exits[w],Debug); // debug exits
                }
            }
        }
        // Yet more
        static int[] loadRoom(int x, int y, int z) // current room loader
        {
            debugCheck(x, y, z); // debugs room

            cavern current = new cavern(); // default config
            if (Map1[x, y, z] != null) // is it null?
                current = Map1[x, y, z]; // no then...
           
            Console.Clear(); // clears console

            Text.Art(current.pic, Console.WindowWidth); // draw pic
            Console.SetCursorPosition(0, Console.CursorTop + 1);

            // Console.SetCursorPosition(0, 10); // sets cursor position
            Text.WordWrap(current.discribe); // writes discription
            Text.WordWrap(" "); // blank line

            for(byte i = 0; i < current.exits.Length; i++) // i = 0 to 5
            Text.WordWrap(current.exits[i]); // writes exits

            input: // label for input statement
            Text.WordWrap(@"What direction do You go (N,S,E,W,U,D), or do you want to check your inventory and the cave's inventory (I)?");
            string choice = string.Format(Console.ReadLine()).ToUpper(); // to upper case
            try // find and return next room
            {
                int c = "NSEWUDI".IndexOf(choice[0]);
                if (c != 6)
                {
                    int[] @return = new int[3] { current.paths[c, 0], current.paths[c, 1], current.paths[c, 2] };
                    Text.Log("Room Index", "Going to: ",Debug);
                    for (int i = 0; i < @return.Length; i++)
                        Text.Log("Room []", @return[i].ToString(), Debug);
                    return @return; // returns next room
                }
                else // inventory
                {
                    Text.WordWrap("");
                    Text.WordWrap("Items found in the cavern.");
                    ShowInventory(current.inventory); // the cavern's inventory

                    Text.WordWrap("");
                    Text.WordWrap("Items found in your inventory.");
                    ShowInventory(Player.inventory); // your inventory

                    Text.WordWrap("");
                    Text.WordWrap("From your inventory...");
                    SelectItem(Player, Map1[x,y,z], current); // items from you to the cave

                    Text.WordWrap("");
                    Text.WordWrap("From the cave...");
                    SelectItem(Map1[x, y, z], Player, current); // items from cave to you
                    goto input; // back to room select
                }
            }
            catch // errror catch
            {
                Text.WordWrap("Error Input, please only use North, South, East, West, Up, and Down as directions or use Inventory. ");
                Text.Log("Input", "Error Invalid: " + choice,Debug);
                goto input; 
            } 
        }

        static void ShowInventory(item[] inv) // show all non null entries in an item array
        {
            foreach (item It in inv)
            {
                if (It != null)
                    Text.WordWrap(string.Format("{0}",It)); // display
            }
        }
        
        static void SelectItem(cavern @in, cavern  @out, cavern current)
        {
            InputSI: // first input retry
            Text.WordWrap("Do you wish to select an item (Y/N)?");
            try
            { 
                string Input = Console.ReadLine().ToUpper(); //line to caps
                if (Input[0] == 'Y') // yes
                {
                InputSIT: // second retry input
                    int a = -1; // variable for invintory entry
                    Text.WordWrap("Item name?");
                    string InputT = Console.ReadLine().ToUpper(); // name querry; case sensitive
                    try
                    {
                        for(var i = 0; i <= @in.inventory.Length; i++) // go through the inventory
                        {
                            item A = @in.inventory[i]; // item to A for easy refference
                            if (A != null) // isn null?
                                if (A.name.ToUpper() == InputT)
                                {
                                    a = i; // record index
                                    break;  
                                }
                        }
                        if (!@in.inventory[a].movable) // movable?
                            Text.WordWrap("This item cannot be moved.");
                        else
                        {
                            InputSETT: // third input retry
                            Text.WordWrap("Transfer item (Y/N)?");
                            string input = Console.ReadLine().ToUpper(); // transfer from @in to @out
                            try
                            {
                                if (input[0] == 'Y') // yes...
                                {
                                    for (int i = 0; i < @out.inventory.Length; i++) //find first null entry in inventory
                                        if (@out.inventory[i] == null)
                                        {
                                            @out.inventory[i] = @in.inventory[a]; // copy item
                                            @in.inventory[a] = null; // delete previous item
                                            Text.Log("Item","Moved "+@out.inventory[i].name,Debug); // log moved item
                                            break;
                                        }
                                    goto InputSI;
                                }
                                else if (input[0] == 'N') // no...
                                {
                                    Text.WordWrap(""); // blank line?
                                }
                            }
                            catch
                            {
                                Text.WordWrap("Invalid input."); // third retry goto...
                                goto InputSETT;
                            }
                        }
                    }
                    catch
                    {
                        Text.WordWrap("Invalid input."); // second retry goto...
                        goto InputSIT;
                    }
                }
                else if (Input[0] == 'N')
                {
                    Text.WordWrap("Closing this inventory"); // exit...
                }
                else
                {
                    Text.WordWrap("Invalid input."); // first retry goto if random reply
                    goto InputSI;
                }
            }
            catch
            {
                Text.WordWrap("Invalid input."); // first retry goto if breaks
                goto InputSI;
            }
        }

        static cavern[,,] Map1 = new cavern[101, 101, 101]; //define the map
        static item temp = new item("Backpack", "This trusty backpack has been with you for years.", false); // debug item
        static cavern Player = new cavern(temp); // player entity soley used for inventory


        static FileStream fs = new FileStream("../../Debug.txt", FileMode.Create, FileAccess.ReadWrite); // starts the debug stream
        static StreamWriter Debug = new StreamWriter(fs); // debug stream

        public static void Main(string[] args)
        {
            Directory.SetCurrentDirectory("../../"); // change directory
            Console.Title = "Cristal Caverns"; // name my window

            Console.SetWindowSize(Console.WindowWidth, Console.WindowHeight); // useless?
            Text.Log("@@@@@@@@@","Debug data for Cristal Caverns",Debug); // auto debug log
            Text.Log("Start Path", System.IO.Path.GetFullPath("..") ,Debug);
            Debug.AutoFlush = true;

            Load(); // load function
            for (int x = 0; x < Map1.GetLength(0); x++) //x iterator
            {
                for (int y = 0; y < Map1.GetLength(1); y++) // y iterator
                {
                    for (int z = 0; z < Map1.GetLength(2); z++) // z iterator
                    {
                        debugCheck(x, y, z); // Debug!
                    }
                }
            }

            int[] exit = new int[3]{ 100, 100, 100 }; // define the win condition
            int[] now = loadRoom(0, 0, 0); // load the start room

            while (true)
            {
                now = loadRoom(now[0], now[1], now[2]); // loads room and displays; returns next room index
                for (int i = 0; i < now.Length; i++) // debug
                    Text.Log("Load Room",now[i].ToString(),Debug);
                if (now[0] == 100 && now[1] == 100 && now[2] == 100) // if I win...
                    break; //exit
            }

            Console.Clear(); // clear
            Text.Art(@"100_100_100.txt", 100); // win image
            Console.SetCursorPosition(0, Console.CursorTop + 1); // down a line
            Text.WordWrap("Press a key to close..."); // close message
            Console.ReadKey(); // pause...
            
        }
    }
}
