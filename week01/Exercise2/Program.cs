using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade percentage:");
        int grade = int.Parse(Console.ReadLine());

        string letter; 

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // print once here
        Console.WriteLine($"You received a {letter}.");

        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course.");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the course.");
        }
    }
}
