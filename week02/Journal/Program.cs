using System;

class Program
{
    // Exceeds requirements:
    // This program automatically creates a backup of the journal when quitting.

    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string choice = "";
        string lastFilename = null; // track last used file

        while (choice != "5")
        {
            Console.WriteLine("\nJournal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    lastFilename = Console.ReadLine();
                    journal.SaveToFile(lastFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    lastFilename = Console.ReadLine();
                    journal.LoadFromFile(lastFilename);
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    journal.AutoBackup(lastFilename);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
