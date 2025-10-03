using System;
using System.Collections.Generic;

namespace Mindfulness
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        public override void Run()
        {
            ShowStartMessage();

            Random rng = new Random();
            string prompt = _prompts[rng.Next(_prompts.Count)];
            Console.WriteLine(prompt);
            Console.WriteLine("You may begin listing in:");
            ShowCountdown(5);

            DateTime end = DateTime.Now.AddSeconds(GetDuration());
            List<string> entries = new List<string>();

            while (DateTime.Now < end)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    entries.Add(input);
                }
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {entries.Count} item(s).");
            int index = 1;
            foreach (var entry in entries)
            {
                Console.WriteLine($"{index++}. {entry}");
            }

            ShowEndMessage();
        }
    }
}
