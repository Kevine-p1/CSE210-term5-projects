using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create sample videos
        var video1 = new Video("Intro to C#", "CodeAcademy", 480);
        var video2 = new Video("Travel Vlog: Rwanda", "WanderWorld", 720);
        var video3 = new Video("Top 5 Python Tips", "DevBytes", 300);

        // Add comments
        video1.AddComment(new Comment("Alice", "Great explanation!"));
        video1.AddComment(new Comment("Bob", "Helped me understand classes."));
        video1.AddComment(new Comment("Clara", "Clear and concise."));

        video2.AddComment(new Comment("Dan", "Rwanda looks beautiful!"));
        video2.AddComment(new Comment("Ella", "Adding this to my bucket list."));
        video2.AddComment(new Comment("Frank", "Amazing shots!"));

        video3.AddComment(new Comment("Grace", "These tips are gold."));
        video3.AddComment(new Comment("Hector", "I learned something new."));
        video3.AddComment(new Comment("Ivy", "Thanks for sharing."));

        // Store videos in a list
        var videos = new List<Video> { video1, video2, video3 };

        // Display details
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length (seconds): {video.LengthSeconds}");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"   {comment.CommenterName}: {comment.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
