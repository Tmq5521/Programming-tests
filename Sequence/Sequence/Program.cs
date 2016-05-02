using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Series";

            int Start;
            int End;
            string Equ;
            int[] nums = new int[1];

            Console.WriteLine("Start:");
            Int32.TryParse(Console.ReadLine(), out Start);

            Console.WriteLine("End:");
            Int32.TryParse(Console.ReadLine(), out End);

            Console.WriteLine(@"With {I} being the variable equation:");
            Equ = Console.ReadLine();


            for (int I = Start; I < End; I++)
            {
                nums[nums.Length - 1] = Int32.Parse(Equ);
                Array.Resize<int>(ref nums, nums.Length + 1);
                
                Console.WriteLine(nums[nums.Length - 2]);
            }
        }
    }
}
