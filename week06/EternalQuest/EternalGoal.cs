using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string title, string description, int points)
            : base(title, description, points)
        {
        }

        // Never completes: each time you record you get points
        public override int RecordEvent()
        {
            return GetPoints();
        }

        public override string GetDetailsString()
        {
            return $"{GetStatusString()} {GetTitle()} ({GetDescription()})";
        }

        public override string GetStatusString() => "[∞]"; // shows it's eternal (not required, but helpful)

        public override string Serialize()
        {
            // Eternal|title|description|points
            return $"Eternal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}";
        }

        private static string Escape(string s) => s.Replace("|", "\\|");
    }
}
