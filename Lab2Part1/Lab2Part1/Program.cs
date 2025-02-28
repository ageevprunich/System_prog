using System.Threading.Tasks;

namespace Lab2Part1
{

//    Завдання
//1. Створити програму, що створює дві задачі, які виконуються паралельно.
//Затримку методом Sleep() організувати на величину 200мс та пропорційно
//ідентифікатору задачі.
//2. Організувати очікування виконання задач методом WaitAll().
//3. Визначити задачу для виконання у вигляді лямбда-виразу.
//4. Створити програму паралельних обчислень за допомогою виклику методу
//Invoke(), де в якості аргументів застосовуються лямбда-вирази.
    class Program
    {
        static void MyTask()
        {
            int taskId = Task.CurrentId ?? -1;
            Console.WriteLine("Task # " + taskId + " is started.");

            for (int count = 0; count < 5; count++)
            {
                Thread.Sleep(200 * taskId);
                Console.WriteLine("Task  # " + taskId + "  counter = " + count);
            }

            Console.WriteLine("Task # " + taskId + "  is done.");
        }
        static void Main (string[] args)
        {
            Console.WriteLine("____Task 1-3____");
            Console.WriteLine("Main Thread is starting.");

            Task tsk1 = Task.Factory.StartNew(() =>
            {
                MyTask(); 
            });

            Task tsk2 = Task.Factory.StartNew(() =>
            {
                MyTask();
            });

            Task.WaitAll(tsk1, tsk2);
            Console.WriteLine("Main() is done.");


            Thread.Sleep(500);


            Console.WriteLine("____Task 4____");
            
            Parallel.Invoke( () => MyTask(), () => MyTask() );

            Console.WriteLine("Main() is done.");
            Console.ReadLine();
        }
    }
    
}