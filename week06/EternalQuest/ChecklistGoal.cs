using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonusPoints;

        public ChecklistGoal(string title, string description, int pointsPer, int targetCount, int bonus)
            : base(title, description, pointsPer)
        {
            _timesCompleted = 0;
            _targetCount = targetCount;
            _bonusPoints = bonus;
        }

        public override int RecordEvent()
        {
            if (_timesCompleted < _targetCount)
            {
                _timesCompleted++;
                // if this made it reach the target, grant points + bonus
                if (_timesCompleted == _targetCount)
                {
                    return GetPoints() + _bonusPoints;
                }
                return GetPoints();
            }
            // already finished -> no points
            return 0;
        }

        public override string GetDetailsString()
        {
            return $"{GetStatusString()} {GetTitle()} ({GetDescription()}) -- Completed {_timesCompleted}/{_targetCount}";
        }

        public override string GetStatusString() => _timesCompleted >= _targetCount ? "[X]" : "[ ]";

        public override string Serialize()
        {
            // Checklist|title|description|points|timesCompleted|targetCount|bonus
            return $"Checklist|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_timesCompleted}|{_targetCount}|{_bonusPoints}";
        }

        private static string Escape(string s) => s.Replace("|", "\\|");
    }
}
