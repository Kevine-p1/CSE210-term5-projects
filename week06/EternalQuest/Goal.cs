using System;

namespace EternalQuest
{
    // Base class for all goals
    public abstract class Goal
    {
        private string _title;
        private string _description;
        private int _points;

        protected Goal(string title, string description, int points)
        {
            _title = title;
            _description = description;
            _points = points;
        }

        public string GetTitle() => _title;
        public string GetDescription() => _description;
        public int GetPoints() => _points;
        public void SetPoints(int p) => _points = p;

        // RecordEvent is abstract: each derived class must implement how an event is recorded
        public abstract int RecordEvent();

        // Default serialization-friendly representation (overridden by some derived classes)
        // Format used for saving: each derived class will output its own line starting with a type token.
        public virtual string GetDetailsString()
        {
            return $"{_title} ({_description})";
        }

        // used to show completion box like [ ] or [X]
        public virtual string GetStatusString() => "[ ]";

        // used for saving; each derived class returns a line like: Simple|title|desc|points|isComplete
        public abstract string Serialize();
    }
}
