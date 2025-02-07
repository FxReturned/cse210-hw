using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are some of your personal strengths?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
        {
            activityName = "Listing Activity";
            activityDescription = "This activity will help you reflect on the good things in your life by having you list as many items as you can in a certain area.";
        }

        public override void StartActivity()
        {
            base.StartActivity();

            Random random = new Random();
            string chosenPrompt = prompts[random.Next(prompts.Count)];
            Console.Clear();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine(chosenPrompt);
            Console.WriteLine("You have 5 seconds to think...");
            ShowCountdown(5);

            Console.Clear();
            Console.WriteLine("Start listing items. After each item, press Enter. When time is up, simply press Enter without typing anything.");

            List<string> userItems = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(durationInSeconds);
            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    string input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        userItems.Add(input);
                    }
                }
                Thread.Sleep(100); 
            }

            Console.WriteLine($"You listed {userItems.Count} item(s).");

            EndActivity();
        }
    }
}
