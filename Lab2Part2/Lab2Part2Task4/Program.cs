using System;
using System.Threading.Tasks;

namespace Lab2Part2Task4
{
    class Program
    {
        static double[] data;
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            data = new double[100000];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            data[1000] = -10;
            ParallelLoopResult loopResult = Parallel.ForEach(data, (v, pls) =>
            {
                if (v < 0) pls.Break();
                Console.WriteLine("Value is: " + v);
            });

            if (!loopResult.IsCompleted)
                Console.WriteLine("ParallelFor was aborted with negative value on iteration " + loopResult.LowestBreakIteration);

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}

