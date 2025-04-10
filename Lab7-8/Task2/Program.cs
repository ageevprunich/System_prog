using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string rootDirectory = @"C:\";
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Write("Введіть назву файлу : ");
        string fileNamePart = Console.ReadLine();

        Console.WriteLine($"\nПошук файлів...\n");

        int totalFound = 0;

        try
        {
            SearchFiles(rootDirectory, fileNamePart, ref totalFound);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Невідома помилка: " + ex.Message);
        }

        Console.WriteLine($"\nУсього знайдено: {totalFound}");
        Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
        Console.ReadKey();
    }

    static void SearchFiles(string currentDirectory, string fileNamePart, ref int count)
    {
        try
        {
            foreach (string file in Directory.GetFiles(currentDirectory))
            {
                if (Path.GetFileName(file).Contains(fileNamePart, StringComparison.OrdinalIgnoreCase))
                {
                    FileInfo info = new FileInfo(file);
                    Console.WriteLine($"Знайдено: {info.FullName}");
                    Console.WriteLine($" - Розмір: {info.Length} байт");
                    Console.WriteLine($" - Створено: {info.CreationTime}");
                    Console.WriteLine($" - Атрибути: {info.Attributes}");
                    Console.WriteLine(new string('-', 50));
                    count++;
                }
            }

            foreach (string dir in Directory.GetDirectories(currentDirectory))
            {
                SearchFiles(dir, fileNamePart, ref count); // рекурсивний виклик
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Пропускаємо директорії без доступу
        }
        
    }
}
