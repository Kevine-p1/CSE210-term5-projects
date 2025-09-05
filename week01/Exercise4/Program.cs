using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<double> numbers = new List<double>();

        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double value))
            {
                if (value == 0)
                    break;  

                numbers.Add(value);
            }
            else
            {
                Console.WriteLine("Invalid number, please try again.");
            }
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        // Sum
        double sum = 0.0;
        foreach (double n in numbers)
            sum += n;

        // Average
        double average = sum / numbers.Count;

        // Max
        double max = numbers[0];
        foreach (double n in numbers)
            if (n > max) max = n;

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}