/*
Exceeds requirements:
 - Ensures no repeat prompts/questions until all are used in a session
 - Logs each activity with timestamp and duration to mindfulness_log.txt
 - Enhanced breathing animation with growing dots
 - Listing activity shows number and list of items entered
*/

using System;
using System.IO;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mindfulness Program";
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness Progjram");
                Console.WriteLine("Choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Log");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice (1-5): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": new BreathingActivity().Run(); Pause(); break;
                    case "2": new ReflectionActivity().Run(); Pause(); break;
                    case "3": new ListingActivity().Run(); Pause(); break;
                    case "4": ShowLog(); Pause(); break;
                    case "5": exit = true; break;
                    default: Console.WriteLine("Invalid choice."); Pause(); break;
                }
            }
            Console.WriteLine("Goodbye! Stay mindful.");
        }

        private static void Pause()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey(true);
        }

        private static void ShowLog()
        {
            string logFile = "mindfulness_log.txt";
            Console.Clear();
            Console.WriteLine("*** Session Log ***");
            if (!File.Exists(logFile))
            {
                Console.WriteLine("No log found.");
                return;
            }
            var lines = File.ReadAllLines(logFile);
            int start = Math.Max(0, lines.Length - 20);
            for (int i = start; i < lines.Length; i++)
                Console.WriteLine(lines[i]);
        }
    }
}


