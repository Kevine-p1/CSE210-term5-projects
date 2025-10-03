using System;
using System.IO;
using System.Threading;

namespace MindfulnessProgram
{
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;
        private static readonly string _logFile = "mindfulness_log.txt";

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public void Run()
        {
            ShowStartingMessage();
            int duration = PromptForDuration();
            _durationSeconds = duration;
            PrepareToBegin();
            DateTime start = DateTime.Now;
            PerformActivity(_durationSeconds);
            DateTime end = DateTime.Now;
            ShowEndingMessage((int)(end - start).TotalSeconds);
            LogSession(_name, (int)(end - start).TotalSeconds);
        }

        private void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"*** {_name} ***");
            Console.WriteLine();
            Console.WriteLine(_description);
            Console.WriteLine();
        }

        private int PromptForDuration()
        {
            Console.Write("Enter duration in seconds (e.g., 30): ");
            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int seconds) && seconds > 0)
                    return seconds;
                Console.Write("Invalid input. Enter a positive integer: ");
            }
        }

        private void PrepareToBegin()
        {
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "/", "-", "\\", "|" };
            int totalIterations = seconds * 10;
            for (int i = 0; i < totalIterations; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(100);
                Console.Write("\b");
            }
            Console.WriteLine();
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        private void ShowEndingMessage(int actualSeconds)
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(2);
            Console.WriteLine($"You have completed the {_name} for {actualSeconds} seconds.");
            ShowSpinner(2);
            Console.WriteLine("Returning to main menu...");
            Thread.Sleep(800);
        }

        private void LogSession(string activityName, int seconds)
        {
            try
            {
                string line = $"{DateTime.Now:u} | {activityName} | {seconds} seconds";
                File.AppendAllText(_logFile, line + Environment.NewLine);
            }
            catch { }
        }

        protected abstract void PerformActivity(int durationSeconds);
    }
}
