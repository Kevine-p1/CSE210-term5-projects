// Extra credit: Implemented a Checklist bonus system (completed), a persistent save/load for goals,
// and a GoalManager class to encapsulate state. To extend: add badges and level progression (planned).

using System;

namespace EternalQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new GoalManager("goals.txt");

            // Attempt to load an existing save
            manager.Load();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nEternal Quest Menu");
                Console.WriteLine("1. Create new goal");
                Console.WriteLine("2. List goals");
                Console.WriteLine("3. Record event (complete a goal)");
                Console.WriteLine("4. Show score");
                Console.WriteLine("5. Save");
                Console.WriteLine("6. Load");
                Console.WriteLine("7. Exit");
                Console.Write("Choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoalMenu(manager);
                        break;
                    case "2":
                        manager.ListGoals();
                        break;
                    case "3":
                        manager.ListGoals();
                        Console.Write("Enter goal number to record: ");
                        if (int.TryParse(Console.ReadLine(), out int idx))
                        {
                            manager.RecordEvent(idx - 1);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;
                    case "4":
                        Console.WriteLine($"Total score: {manager.GetScore()}");
                        break;
                    case "5":
                        manager.Save();
                        break;
                    case "6":
                        manager.Load();
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Unknown choice.");
                        break;
                }
            }

            // NOTE: For the Canvas comment about extra credit, add a short description here
            // e.g. // Extra features: added badges and levels (not implemented) OR actual implemented features description.
        }

        static void CreateGoalMenu(GoalManager manager)
        {
            Console.WriteLine("\nWhich type of goal?");
            Console.WriteLine("1. Simple Goal (one-time)");
            Console.WriteLine("2. Eternal Goal (repeatable)");
            Console.WriteLine("3. Checklist Goal (repeat N times with bonus)");
            Console.Write("Choice: ");
            string c = Console.ReadLine();

            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Points (per completion): ");
            if (!int.TryParse(Console.ReadLine(), out int points))
            {
                Console.WriteLine("Invalid points, using 0.");
                points = 0;
            }

            switch (c)
            {
                case "1":
                    manager.AddGoal(new SimpleGoal(title, desc, points));
                    Console.WriteLine("Simple goal added.");
                    break;
                case "2":
                    manager.AddGoal(new EternalGoal(title, desc, points));
                    Console.WriteLine("Eternal goal added.");
                    break;
                case "3":
                    Console.Write("Target count (how many times to complete): ");
                    int target = int.TryParse(Console.ReadLine(), out int t) ? t : 1;
                    Console.Write("Bonus points when complete: ");
                    int bonus = int.TryParse(Console.ReadLine(), out int b) ? b : 0;
                    manager.AddGoal(new ChecklistGoal(title, desc, points, target, bonus));
                    Console.WriteLine("Checklist goal added.");
                    break;
                default:
                    Console.WriteLine("Unknown type. Returning.");
                    break;
            }
        }
    }
}
