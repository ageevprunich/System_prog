﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Part2Task3
{
    class Program
    {
        static double[] data;
        //Метод, що служить в якості тіла паралельного циклу.
        static void MyTransform(double v, ParallelLoopState pls)
        {
            //завершити цикл, якщо знайдено від'ємне значення
            if (v < 0) pls.Break();
            Console.WriteLine("Value is :" + v);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread is starting.");
            data = new double[100000];
            //Ініціювати дані в звичайному циклі for
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i;
            }
            //Помістити від'ємне значення в масив
            data[1000] = -10;
            //Розпаралелити цикл методом Parallel.For
            ParallelLoopResult loopResult = Parallel.ForEach(data, MyTransform);

            //Перевірити, чи завершився цикл
            if (!loopResult.IsCompleted)
                Console.WriteLine("ParallelFor was aborted with negative value on iteration " + loopResult.LowestBreakIteration);
            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
}