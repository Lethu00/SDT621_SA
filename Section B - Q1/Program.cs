using System;

namespace Section_B___Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Structure of C# Program Demo!");
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine($"Hello {name}!");
            
            Console.WriteLine("\nThis program demonstrates the structure of a C# program.");
            Console.WriteLine("1. using System: imports functionality");
            Console.WriteLine("2. namespace: organizes code.");
            Console.WriteLine("3. class Program: container for code.");
            Console.WriteLine("4. Main(): entry point of  program.");
            Console.WriteLine("5. Comments: explain logic and documentation.");
        }
    }
}