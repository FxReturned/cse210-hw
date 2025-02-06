using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Video> videos = new List<Video>();

            Video video1 = new Video("Introduction to C#", "John Doe", 300);
            video1.Comments.Add(new Comment("Mary", "Great explanation!"));
            video1.Comments.Add(new Comment("Peter", "Very useful, thanks."));
            video1.Comments.Add(new Comment("Anna", "Do you have more tutorials?"));
            videos.Add(video1);

            Video video2 = new Video("Object-Oriented Programming", "Luis Gomez", 450);
            video2.Comments.Add(new Comment("Carlos", "Good content."));
            video2.Comments.Add(new Comment("Elena", "Helped me understand OOP better."));
            video2.Comments.Add(new Comment("Michael", "Interesting, hope to see more."));
            videos.Add(video2);

            Video video3 = new Video("Handling Lists in C#", "Sofia Martinez", 600);
            video3.Comments.Add(new Comment("Diego", "Awesome!"));
            video3.Comments.Add(new Comment("Laura", "Very practical, thanks."));
            video3.Comments.Add(new Comment("Sergio", "What's the difference between List and Array?"));
            videos.Add(video3);

            foreach (Video video in videos)
            {
                Console.WriteLine("----------------------------");
                Console.WriteLine();
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} seconds");
                Console.WriteLine($"Number of comments: {video.GetCommentCount()}");
                Console.WriteLine("Comments:");
                foreach (Comment comment in video.Comments)
                {
                    Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
