using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string title, string description, int points)
            : base(title, description, points)
        {
            _isComplete = false; // default initial state
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return GetPoints();
            }

            // If already complete, no points
            return 0;
        }

        public override string GetDetailsString()
        {
            return $"{GetStatusString()} {GetTitle()} ({GetDescription()})";
        }

        public override string GetStatusString() => _isComplete ? "[X]" : "[ ]";

        public override string Serialize()
        {
            // Simple|title|description|points|isComplete
            return $"Simple|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_isComplete}";
        }

        private static string Escape(string s) => s.Replace("|", "\\|");
    }
}
