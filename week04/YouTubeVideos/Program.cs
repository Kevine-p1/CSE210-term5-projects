using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
         
        Video v1 = new Video { Title = "Intro to C#", Author = "CodeAcademy", LengthSeconds = 480 };
        Video v2 = new Video { Title = "Travel Vlog: Rwanda", Author = "WanderWorld", LengthSeconds = 720 };
        Video v3 = new Video { Title = "Top 5 Python Tips", Author = "DevBytes", LengthSeconds = 300 };

        // Add comments
        v1.AddComment(new Comment("Alice", "Great explanation!"));
        v1.AddComment(new Comment("Bob", "Helped me understand classes."));
        v1.AddComment(new Comment("Clara", "Clear and concise."));

        v2.AddComment(new Comment("Dan", "Rwanda looks beautiful!"));
        v2.AddComment(new Comment("Ella", "Adding this to my bucket list."));
        v2.AddComment(new Comment("Frank", "Amazing shots!"));

        v3.AddComment(new Comment("Grace", "These tips are gold."));
        v3.AddComment(new Comment("Hector", "I learned something new."));
        v3.AddComment(new Comment("Ivy", "Thanks for sharing."));

        
        List<Video> videos = new List<Video> { v1, v2, v3 };

         
        foreach (Video v in videos)
        {
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length (seconds): {v.LengthSeconds}");
            Console.WriteLine($"Number of comments: {v.GetNumberOfComments()}");

            foreach (Comment c in v.GetComments())
            {
                Console.WriteLine($"   {c.CommenterName}: {c.Text}");
            }

            Console.WriteLine(new string('-', 40));
        }
    }
}
