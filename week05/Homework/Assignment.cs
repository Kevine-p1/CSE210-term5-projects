using System;

class Assignment
{
    // Protected so derived classes can access directly
    protected string _studentName;
    protected string _topic;

    // Constructor
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Method to get summary
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Optional: getter for student name (if you want private variables instead)
    // public string GetStudentName() => _studentName;
}
