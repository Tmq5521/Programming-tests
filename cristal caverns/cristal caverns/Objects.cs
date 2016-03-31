using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CFL;

namespace cristal_caverns
{


    public class cavern //object template for each room
    {
        public int[] pos { get; set; } = { 0, 0, 0 }; // position in array
        public string discribe { get; set; } = "null";// strings containing discription of the room
        public string[] exits { get; set; } = { "North", "South", "East", "West", "Up", "Down" }; //strings containing discriptions of the exits
        public int[,] paths { get; set; } = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } }; //array containing the path each exit takes
        public item[] inventory { get; set; } = new item[100]; // array containing Items on the ground
        public string pic = "404.txt"; // ascii art pic file

        public cavern() // empty constructor
        { }

        public cavern(int[] Pos, string Discribe, string[] Exits, int[,] Paths, string Pic) // Room constructor
        {
            // sets variables in the new object
            pos = Pos;
            discribe = Discribe;
            exits = Exits;
            paths = Paths;
            pic = Pic;
        }

        public cavern(item i) // single item construtor
        {
            inventory[99] = i;
        }

        // Return the point's value as a string.
        public override String ToString()
        {
            return string.Format("({0}, {1}, {2}) ({3}) ({4})", pos[0], pos[1], pos[2], discribe, exits[0]);
            //string[] Text = {discribe, exits};
            //return string.Format(Text);
        }



        // Return a copy of this point object by making a simple field copy.
        public cavern Copy()
        {
            return (cavern)this.MemberwiseClone();
        }
    }

    public class item //object template for Items
    {
        public string name { get; set; } = @"_"; // Item Name
        public bool movable { get; set; } = false; // Item Movability
        public string discription { get; set; } = null; // Item Discription

        public item() // empty constructor
        { }

        public item(string Name, string Discription, bool Movable) // sets Variables
        {
            name = Name;
            discription = Discription;
            movable = Movable;
        }

        public bool equals() // overides the string value of this object
        {
            return (name == @"_");

        }

        public item Copy()
        {
            return (item)this.MemberwiseClone();
        }

        public override String ToString() //tostring overide
        {
            return string.Format("{0}, {1}", name, discription);
        }
    }

    public class player
    {
        public string name { get; set; } = "";
        public item[] inventory { get; set; } = new item[100000000];

        public player(string Name)
        {
            name = Name;
        }

        public override String ToString()
        {
            return string.Format("{0}", name);
        }
    }
}
