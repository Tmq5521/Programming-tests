using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Alarm
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "Alarm";

            Console.WriteLine("Time? (H:M)");
            string time = Console.ReadLine();

            int hour = DateTime.Now.Hour;
            int min = DateTime.Now.Minute;

            while (String.Format("{0}:{1}", hour, min) != time)
            {
                hour = DateTime.Now.Hour;
                min = DateTime.Now.Minute;

            }

            Console.Beep(440, 60000*10);

            Console.ReadLine();



        }
    }
}
