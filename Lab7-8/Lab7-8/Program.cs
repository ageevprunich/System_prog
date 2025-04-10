using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; 
        Console.Write("Введіть шлях до директорії: ");
        string path = Console.ReadLine();

        if (Directory.Exists(path))
        {
            Console.WriteLine("Ієрархічна структура директорії:");
            PrintDirectoryStructure(path, 0);
        }
        else
        {
            Console.WriteLine("Вказана директорія не існує.");
        }
    }

    static void PrintDirectoryStructure(string path, int indentLevel)
    {
        string indent = new string(' ', indentLevel * 2);

        try
        {
            // Вивід папок
            string[] directories = Directory.GetDirectories(path);
            foreach (string dir in directories)
            {
                Console.WriteLine($"{indent}[DIR] {Path.GetFileName(dir)}");
                PrintDirectoryStructure(dir, indentLevel + 1); // Рекурсія
            }

            // Вивід файлів
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                Console.WriteLine($"{indent}     {Path.GetFileName(file)}");
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"{indent}[NO ACCESS]");
        }
    }
}


