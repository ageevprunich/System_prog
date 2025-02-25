using System;
using System.Threading;

namespace ThreadPriority
{
    class MyThread
    {
        public int Count;
        public Thread Thrd;
        static bool stop = false;
        static string currentName;

        public MyThread(string name)
        {
            Count = 0;
            Thrd = new Thread(Run);
            Thrd.Name = name;
            currentName = name;
        }

        void Run()
        {
            Console.WriteLine("Thread " + Thrd.Name + " is beginning.");
            do
            {
                Count++;
                if (currentName != Thrd.Name)
                {
                    currentName = Thrd.Name;
                    Console.WriteLine("In thread " + currentName);
                }
            } while (stop == false && Count < 1e9);
            stop = true;
            Console.WriteLine("Thread " + Thrd.Name + " is completed.");
        }
    }

    class Program
    {
        static void Main()
        {
            MyThread mt1 = new MyThread("Highest");
            MyThread mt2 = new MyThread("Lowest");
            MyThread mt3 = new MyThread("AboveNormal");
            MyThread mt4 = new MyThread("Normal");
            MyThread mt5 = new MyThread("BelowNormal");


            mt1.Thrd.Priority = System.Threading.ThreadPriority.Highest;
            mt2.Thrd.Priority = System.Threading.ThreadPriority.Lowest;
            mt3.Thrd.Priority = System.Threading.ThreadPriority.AboveNormal;
            mt4.Thrd.Priority = System.Threading.ThreadPriority.Normal;
            mt5.Thrd.Priority = System.Threading.ThreadPriority.BelowNormal;

            mt1.Thrd.Start();
            mt2.Thrd.Start();
            mt3.Thrd.Start();
            mt4.Thrd.Start();
            mt5.Thrd.Start();

            mt1.Thrd.Join();
            mt2.Thrd.Join();
            mt3.Thrd.Join();
            mt4.Thrd.Join();
            mt5.Thrd.Join();

            Console.WriteLine();
            Console.WriteLine("Thread " + mt1.Thrd.Name + " counted to " + mt1.Count);
            Console.WriteLine("Thread " + mt2.Thrd.Name + " counted to " + mt2.Count);
            Console.WriteLine("Thread " + mt3.Thrd.Name + " counted to " + mt3.Count);
            Console.WriteLine("Thread " + mt4.Thrd.Name + " counted to " + mt4.Count);
            Console.WriteLine("Thread " + mt5.Thrd.Name + " counted to " + mt5.Count);

            Console.ReadLine();


        }
    }
}
