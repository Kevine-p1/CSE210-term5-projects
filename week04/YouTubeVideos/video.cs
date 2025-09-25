using System;
using System.Collections.Generic;

public class Video
{
    // Properties
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthSeconds { get; set; }

    // List of comments
    private List<Comment> comments = new List<Comment>();

    // Add a comment to this video
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Return the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    // Provide read-only access to comments
    public List<Comment> GetComments()
    {
        return comments;
    }
}
