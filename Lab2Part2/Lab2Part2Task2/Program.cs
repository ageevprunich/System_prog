using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Lab2Part2Task2
{
    class Program
    {
        static int[] intData;
        static double[] doubleData;
        const double target = 73582;
        const double deviation = 250;

        static void CalculationInt(int i, int formula, ParallelLoopState loopState = null)
        {
            switch (formula)
            {
                case 1: intData[i] = intData[i] / 10; break;
                case 2: intData[i] = (int)(intData[i] / Math.PI); break;
                case 3: intData[i] = (int)(Math.Exp(intData[i]) / Math.Pow(intData[i], Math.PI)); break;
                case 4: intData[i] = (int)(Math.Exp(Math.PI * intData[i]) / Math.Pow(intData[i], Math.PI)); break;
            }
            if (loopState != null && Math.Abs(intData[i] - target) <= deviation)
            {
                Console.WriteLine($"Breaking int loop at index {i}, value = {intData[i]}");
                loopState.Break();
            }
        }

        static void CalculationDouble(int i, int formula, ParallelLoopState loopState = null)
        {
            switch (formula)
            {
                case 1: doubleData[i] = doubleData[i] / 10; break;
                case 2: doubleData[i] = doubleData[i] / Math.PI; break;
                case 3: doubleData[i] = Math.Exp(doubleData[i]) / Math.Pow(doubleData[i], Math.PI); break;
                case 4: doubleData[i] = Math.Exp(Math.PI * doubleData[i]) / Math.Pow(doubleData[i], Math.PI); break;
            }
            if (loopState != null && Math.Abs(doubleData[i] - target) <= deviation)
            {
                Console.WriteLine($"Breaking double loop at index {i}, value = {doubleData[i]:F2}");
                loopState.Break();
            }
        }

        static void SerialInt(int formula)
        {
            for (int i = 0; i < intData.Length; i++)
            {
                CalculationInt(i, formula);
            }
        }

        static void SerialDouble(int formula)
        {
            for (int i = 0; i < doubleData.Length; i++)
            {
                CalculationDouble(i, formula);
            }
        }

        static void ParallelInt(int formula)
        {
            ParallelLoopResult result = Parallel.For(0, intData.Length, (i, loopState) =>
            {
                CalculationInt(i, formula, loopState);
            });

            if (!result.IsCompleted)
                Console.WriteLine($"Parallel int loop exited at iteration {result.LowestBreakIteration}");
        }

        static void ParallelDouble(int formula)
        {
            ParallelLoopResult result = Parallel.For(0, doubleData.Length, (i, loopState) =>
            {
                CalculationDouble(i, formula, loopState);
            });

            if (!result.IsCompleted)
                Console.WriteLine($"Parallel double loop exited at iteration {result.LowestBreakIteration}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Main starts");
            int[] sizes = { 500000, 5000000 };
            int[] formulas = { 1, 2, 3, 4 };
            foreach (int size in sizes)
            {
                foreach (int formula in formulas)
                {
                    Console.WriteLine($"Size: {size}, formula: {formula}");
                    intData = new int[size];
                    doubleData = new double[size];
                    for (int i = 0; i < size; i++)
                    {
                        intData[i] = i + 1;
                        doubleData[i] = i + 1;
                    }
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    SerialInt(formula);
                    sw.Stop();
                    Console.WriteLine($"Serial time for int: {sw.Elapsed.TotalSeconds} sec");
                    sw.Reset();
                    sw.Start();
                    SerialDouble(formula);
                    sw.Stop();
                    Console.WriteLine($"Serial time for double: {sw.Elapsed.TotalSeconds} sec");
                    for (int i = 0; i < size; i++)
                    {
                        intData[i] = i + 1;
                        doubleData[i] = i + 1;
                    }
                    sw.Reset();
                    sw.Start();
                    ParallelInt(formula);
                    sw.Stop();
                    Console.WriteLine($"Parallel time for int: {sw.Elapsed.TotalSeconds} sec");
                    sw.Reset();
                    sw.Start();
                    ParallelDouble(formula);
                    sw.Stop();
                    Console.WriteLine($"Parallel time for double: {sw.Elapsed.TotalSeconds} sec");
                }
            }
            Console.WriteLine("Completed");
            Console.ReadLine();
        }
    }
}



