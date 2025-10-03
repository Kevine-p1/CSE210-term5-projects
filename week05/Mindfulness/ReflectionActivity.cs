using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience?",
            "What did you learn about yourself?",
            "How can you keep this in mind in the future?"
        };

        private Random _rng = new Random();
        private List<int> _unusedPrompts;
        private List<int> _unusedQuestions;

        public ReflectionActivity()
            : base("Reflection Activity",
                   "This activity will help you reflect on times in your life when you have shown strength and resilience.")
        {
            _unusedPrompts = new List<int>();
            for (int i = 0; i < _prompts.Count; i++) _unusedPrompts.Add(i);

            _unusedQuestions = new List<int>();
            for (int i = 0; i < _questions.Count; i++) _unusedQuestions.Add(i);
        }

        protected override void PerformActivity(int durationSeconds)
        {
            if (_unusedPrompts.Count == 0)
                for (int i = 0; i < _prompts.Count; i++) _unusedPrompts.Add(i);

            int promptIndex = PopRandomIndex(_unusedPrompts);
            Console.WriteLine();
            Console.WriteLine(_prompts[promptIndex]);
            Console.WriteLine();

            Console.Write("You may begin reflecting in: ");
            ShowCountdown(5);
            Console.WriteLine();

            DateTime endTime = DateTime.Now.AddSeconds(durationSeconds);

            while (DateTime.Now < endTime)
            {
                if (_unusedQuestions.Count == 0)
                    for (int i = 0; i < _questions.Count; i++) _unusedQuestions.Add(i);

                int qIdx = PopRandomIndex(_unusedQuestions);
                Console.WriteLine($"- {_questions[qIdx]}");
                int remaining = (int)(endTime - DateTime.Now).TotalSeconds;
                int pause = Math.Min(7, Math.Max(1, remaining));
                ShowSpinner(pause);
            }
        }

        private int PopRandomIndex(List<int> list)
        {
            int idx = _rng.Next(list.Count);
            int val = list[idx];
            list.RemoveAt(idx);
            return val;
        }
    }
}
