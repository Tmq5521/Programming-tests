using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simplify_Expression
{
    class CFL
    {
        public static List<List<int>> parseParams(string str)
        {
            int[] @params = new int[str.Length];
            List<List<int>> pairs = new List<List<int>>(1);
            int i = 0;

            foreach (char @char in str)
            {
                if (@char == '(')
                {
                    @params[i] = 1;
                }
                else if (@char == ')')
                {
                    @params[i] = -1;
                }
                else
                {
                    @params[i] = 0;
                }
                i += 1;
            }
            
            for (i = 0; i < str.Length; ++i)
            {
                if (@params[i] == 1)
                {
                    for (int j = i+1; j < str.Length; ++j)
                    {
                        if (sumPart(@params, i, j) == 0)
                        {
                            List<int> @temp = new List<int>(2);
                            @temp.Add(i);
                            @temp.Add(j);
                            pairs.Add( @temp );
                            break;
                        }
                    }
                }
            }

            return pairs;
        }

        static int sumPart(int[] list, int start, int end )
        {
            int sum = 0;
            for (int i = start; i <= end; ++i)
            {
                sum += list[i];
            }
            return sum;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> @out = CFL.parseParams(Console.ReadLine());

            Console.Write("[");
            foreach (List<int> @list in @out)
            {
                Console.Write(String.Format("[{0},{1}]", @list[0], @list[1]));
            }
            Console.WriteLine("]");
            Console.ReadKey();
        }
    }
}
