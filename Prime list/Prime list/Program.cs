using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Prime_list
{
    class Program
    {

        static ulong IsPrime(ulong i, ulong[] nums, ulong index)
        {
            double Root = Math.Sqrt(i);
            for (ulong e = 1;nums[e] <= Root; ++e)
            {
                if (i % nums[e] == 0)
                    return i;
            }
            nums[index] = i;
            index += index;
            return i;
        }


        static void Main(string[] args)
        {
            Console.Title = "Primes";
            Stopwatch St1 = new Stopwatch();
            St1.Reset();
            St1.Start();

            ulong amount = 20000000;
            ulong[] nums = new ulong[amount];
            nums[0] = 2;
            nums[1] = 3;
            ulong index = 2;
            ulong i = 3;
            ulong I = 3;

            //while (amount > index)
            while(amount >= i)
            {
                i += 2;
                if (Math.Sqrt(I) < i)
                {
                   I = IsPrime(i, nums, index);
                    if (nums[index] != 0)
                        index += 1;
                }
                //if (IsPrime(i, nums, index))
                //{
                //    nums[index] = i;
                //    index = ++index;
                //} 
            }

            St1.Stop();
            Console.WriteLine(St1.ElapsedMilliseconds);
            Console.ReadKey();
        }
    }
}
