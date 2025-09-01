using System;

class Program
{
    static void Main(string[] args)
    {
         Console.WriteLine("Enter your first name:");
         string firstName = Console.ReadLine();
         Console.WriteLine("Enter your second name:");
         string secondName = Console.ReadLine();
         Console.WriteLine($"Your name is {secondName}, {firstName} {secondName}");
    }
    }
