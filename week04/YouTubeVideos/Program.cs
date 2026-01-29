using System;

class Program
{
    static void Main(string[] args)
    {
     
        // Add at least 3 videos, each with at least 2 comments.
        List<Video> videos = new List<Video>();
        Video video1 = new Video("C# Tutorial", "John Doe", 600);
        video1.AddComment(new Comment("Alice", "Great tutorial!"));
        video1.AddComment(new Comment("Bob", "Very helpful, thanks!"));
        videos.Add(video1);
        Video video2 = new Video("Learn Python", "Jane Smith", 800);
        video2.AddComment(new Comment("Charlie", "Loved it!"));
        video2.AddComment(new Comment("Dave", "Can't wait to try this out."));
        videos.Add(video2);
        Video video3 = new Video("JavaScript Basics", "Mike Johnson", 500);
        video3.AddComment(new Comment("Eve", "This was so informative."));
        video3.AddComment(new Comment("Frank", "Thanks for sharing!"));
        videos.Add(video3);

        //Finally, have the program display the details of each video, 
        // including the title, author, length, number of comments, and the comments themselves.
        foreach (Video video in videos)
        {
            Console.Clear();
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length (seconds): {video._lengthInSeconds}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"\t{comment._commenterName}: {comment._text}");
            }
            Console.WriteLine();
        }
    }
}