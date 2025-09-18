// EXCEEDS REQUIREMENTS:
// 1. Adds a "show" command so the user can reveal the full scripture at any time
//    to check their memory before continuing to hide more words.

using System;

class Program
{
    static void Main()
    {
        // Create the reference (multi-verse example)
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        // Create the scripture text
        Scripture scripture = new Scripture(reference,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding. "
          + "In all thy ways acknowledge him, and he shall direct thy paths.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, type 'show' to reveal full scripture, or 'quit' to exit.");

            string input = Console.ReadLine()?.Trim().ToLower();

            if (input == "quit")
                break;

            if (input == "show")
            {
                Console.Clear();
                Console.WriteLine("Full scripture for review:\n");
                Console.WriteLine(scripture.GetFullText());
                Console.WriteLine("\nPress Enter to continue hiding or type 'quit' to exit.");
                if (Console.ReadLine()?.Trim().ToLower() == "quit")
                    break;
                continue; // don’t hide words this round
            }

            scripture.HideRandomWords(3);

            if (scripture.AllHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                break;
            }
        }
    }
}

