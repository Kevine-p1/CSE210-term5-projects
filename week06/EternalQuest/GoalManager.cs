using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // Non-static manager class to hold goals and the user's score (demonstrates member variables)
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _totalScore;
        private readonly string _saveFilePath;

        public GoalManager(string saveFile = "goals.txt")
        {
            _goals = new List<Goal>();
            _totalScore = 0;
            _saveFilePath = saveFile;
        }

        public int GetScore() => _totalScore;

        public void AddGoal(Goal g) => _goals.Add(g);

        public void ListGoals()
        {
            Console.WriteLine("\nYour goals:");
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
            Console.WriteLine();
        }

        public void RecordEvent(int index)
        {
            if (index < 0 || index >= _goals.Count)
            {
                Console.WriteLine("Invalid goal index.");
                return;
            }

            Goal g = _goals[index];
            int pts = g.RecordEvent();
            _totalScore += pts;
            Console.WriteLine($"You earned {pts} points. Total score: {_totalScore}.");
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter(_saveFilePath))
            {
                // first line: total score
                writer.WriteLine(_totalScore);
                // then each goal as a serialized line
                foreach (var g in _goals)
                {
                    writer.WriteLine(g.Serialize());
                }
            }
            Console.WriteLine($"Saved to {_saveFilePath}");
        }

        public void Load()
        {
            if (!File.Exists(_saveFilePath))
            {
                Console.WriteLine("No save file found.");
                return;
            }

            _goals.Clear();
            string[] lines = File.ReadAllLines(_saveFilePath);
            if (lines.Length == 0) return;
            if (!int.TryParse(lines[0], out _totalScore)) _totalScore = 0;

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];
                // simple parser respecting escaped pipes (we used \| to escape)
                var parts = SplitPreserveEscapes(line, '|');

                if (parts.Count == 0) continue;

                string type = parts[0];
                try
                {
                    if (type == "Simple")
                    {
                        // Simple|title|description|points|isComplete
                        var title = Unescape(parts[1]);
                        var desc = Unescape(parts[2]);
                        int points = int.Parse(parts[3]);
                        bool isComplete = bool.Parse(parts[4]);
                        var sg = new SimpleGoal(title, desc, points);
                        if (isComplete)
                        {
                            // mark as complete by recording an event if not already done
                            sg.RecordEvent(); // SimpleGoal records points only first time, but we don't re-add points on load
                            // but since RecordEvent actually gives points, we should instead set the private state via workaround:
                            // Simplest: create a new completed object by casting or reflection is ugly.
                            // We'll set points adjustment: to avoid changing score on load, we need a small workaround:
                            // For simplicity, we can keep a completed SimpleGoal by serializing it as completed in our class.
                            // But since SimpleGoal currently uses private field, we cannot set it. So better approach:
                            // Replace logic: after creating, if isComplete then call sg.RecordEvent() and subtract points from _totalScore
                            // But current code here cannot access _totalScore. So instead we will set a flag by directly toggling via serialization in future.
                            // To stay simple, we will mark it complete by calling RecordEvent() and then remove the points from _totalScore.
                            // That requires capturing points:
                            int p = sg.RecordEvent();
                            _totalScore -= p; // undo awarding points on load; preserves the recorded state.
                        }
                        _goals.Add(sg);
                    }
                    else if (type == "Eternal")
                    {
                        // Eternal|title|description|points
                        var title = Unescape(parts[1]);
                        var desc = Unescape(parts[2]);
                        int points = int.Parse(parts[3]);
                        _goals.Add(new EternalGoal(title, desc, points));
                    }
                    else if (type == "Checklist")
                    {
                        // Checklist|title|description|points|timesCompleted|targetCount|bonus
                        var title = Unescape(parts[1]);
                        var desc = Unescape(parts[2]);
                        int points = int.Parse(parts[3]);
                        int done = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]);
                        var cg = new ChecklistGoal(title, desc, points, target, bonus);
                        // apply done times without changing total score (we'll subtract awarded points then)
                        int awarded = 0;
                        for (int t = 0; t < done; t++)
                        {
                            awarded += cg.RecordEvent();
                        }
                        _totalScore -= awarded; // undo awarding when loading
                        _goals.Add(cg);
                    }
                }
                catch
                {
                    // ignore malformed lines
                }
            }
            Console.WriteLine("Loaded saved goals.");
        }

        // small helpers to parse escaped pipe format
        private static List<string> SplitPreserveEscapes(string s, char sep)
        {
            var parts = new List<string>();
            var current = "";
            bool esc = false;
            foreach (char c in s)
            {
                if (esc)
                {
                    current += c;
                    esc = false;
                }
                else if (c == '\\')
                {
                    esc = true;
                }
                else if (c == sep)
                {
                    parts.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
            parts.Add(current);
            return parts;
        }

        private static string Unescape(string s) => s.Replace("\\|", "|");
    }
}
