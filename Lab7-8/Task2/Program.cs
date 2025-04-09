using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Введіть повний шлях до файлу: ");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            FileInfo info = new FileInfo(filePath);

            Console.WriteLine("\nІнформація про файл:");
            Console.WriteLine($"  Повний шлях: {info.FullName}");
            Console.WriteLine($"  Розмір: {info.Length} байт");
            Console.WriteLine($"  Дата створення: {info.CreationTime}");
            Console.WriteLine($"  Атрибути: {info.Attributes}");
        }
        else
        {
            Console.WriteLine("Файл не знайдено за вказаним шляхом.");
        }
    }
}
