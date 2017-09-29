using System;

namespace PrintRandomText
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] inputs = System.IO.File.ReadAllLines(@"..\..\In.txt");

            Console.WriteLine("How many repititions?: ");
            long num = Int64.Parse( Console.ReadLine());

            string[] outputs = new string[num];

            for (int i = 0; i < num; ++i)
            {
                int randIndex = Convert.ToInt32(Math.Round( (rand.NextDouble()) * (inputs.Length - 1), 0));
                outputs[i] = inputs[randIndex];
            }

            System.IO.File.WriteAllLines(@"..\..\Out.txt", outputs); 
        }
    }
}