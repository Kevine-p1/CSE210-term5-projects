using System;
using System.Collections.Generic;

public class Video
{
    // Private fields use _underscoreCamelCase
    private string _title;
    private string _author;
    private int _lengthSeconds;
    private List<Comment> _comments = new List<Comment>();

    // Constructor
    public Video(string title, string author, int lengthSeconds)
    {
        _title = title;
        _author = author;
        _lengthSeconds = lengthSeconds;
    }

    // Public getters (no setters needed for this assignment)
    public string Title => _title;
    public string Author => _author;
    public int LengthSeconds => _lengthSeconds;

    // Add a comment
    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    // Return number of comments
    public int GetNumberOfComments()
    {
        return _comments.Count;
    }

    // Return the comment list (read-only)
    public List<Comment> GetComments()
    {
        return _comments;
    }
}
