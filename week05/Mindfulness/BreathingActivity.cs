using System;
using System.Threading;

namespace MindfulnessProgram
{
    class BreathingActivity : Activity
    {
        private int _inhaleSeconds = 4;
        private int _exhaleSeconds = 6;

        public BreathingActivity()
            : base("Breathing Activity",
                   "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        { }

        protected override void PerformActivity(int durationSeconds)
        {
            DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);
            bool inhale = true;

            while (DateTime.Now < endTime)
            {
                if (inhale)
                {
                    Console.WriteLine("Breathe in...");
                    int secs = Math.Min(_inhaleSeconds, (int)(endTime - DateTime.Now).TotalSeconds);
                    if (secs <= 0) break;
                    ShowAnimatedCount(secs);
                }
                else
                {
                    Console.WriteLine("Breathe out...");
                    int secs = Math.Min(_exhaleSeconds, (int)(endTime - DateTime.Now).TotalSeconds);
                    if (secs <= 0) break;
                    ShowAnimatedCount(secs);
                }
                inhale = !inhale;
            }
        }

        private void ShowAnimatedCount(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write($" {i} ");
                int dotCount = seconds - i + 1;
                for (int d = 0; d < dotCount; d++) Console.Write(".");
                Thread.Sleep(1000);
                Console.Write("\r" + new string(' ', 20) + "\r");
            }
            Console.WriteLine();
        }
    }
}
