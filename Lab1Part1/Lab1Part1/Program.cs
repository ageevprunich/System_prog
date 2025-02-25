namespace ThreadPriority
{
    class MyThread
    {
        public int Count;
        public Thread Thrd;
        static bool stop = false;
        static string currentName;
        //Сконструювати, але не починати виконання нового потоку
        public MyThread(string name)
        {
            
        Count = 0;
            Thrd = new Thread(Run);
            Thrd.Name = name;
            currentName = name;
        }
        //Почати виконання нового потоку
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
            MyThread mt1 = new MyThread("With High priority.");
            MyThread mt2 = new MyThread("with Low priority.");
            //Встановити пріоритети для потоків
            //Вище середнього
            mt1.Thrd.Priority = System.Threading.ThreadPriority.AboveNormal;
            //Нижче середнього
            mt2.Thrd.Priority = System.Threading.ThreadPriority.BelowNormal;
            //Почати потоки
            mt1.Thrd.Start();
            mt2.Thrd.Start();
            mt1.Thrd.Join();
            mt2.Thrd.Join();
            Console.WriteLine();
            Console.WriteLine("Thread " + mt1.Thrd.Name + " counted to " + mt1.Count);
            Console.WriteLine("Thread " + mt2.Thrd.Name + " counted to " + mt2.Count);
            Console.ReadLine();
        }
    }
}
