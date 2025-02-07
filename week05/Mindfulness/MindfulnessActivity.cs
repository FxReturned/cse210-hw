using System;
using System.Threading;

namespace MindfulnessProgram
{
    public class MindfulnessActivity
    {
        protected string activityName;
        protected string activityDescription;
        protected int durationInSeconds;

        public virtual void StartActivity()
        {
            Console.Clear();
            Console.WriteLine($"Starting {activityName}...");
            Console.WriteLine(activityDescription);
            Console.WriteLine("Enter the duration (in seconds):");
            if (int.TryParse(Console.ReadLine(), out durationInSeconds))
            {
                Console.WriteLine("Get ready...");
                ShowSpinner(3);
            }
            else
            {
                Console.WriteLine("Invalid input. Using default duration of 30 seconds.");
                durationInSeconds = 30;
                ShowSpinner(3);
            }
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write($"{i} ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected void ShowSpinner(int seconds)
        {
            int spinnerIndex = 0;
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[spinnerIndex]);
                spinnerIndex = (spinnerIndex + 1) % spinner.Length;
                Thread.Sleep(250);
                Console.Write("\b");
            }
            Console.Write(" \b");
            Console.WriteLine();
        }

        public virtual void EndActivity()
        {
            ActivityLog.LogActivity(activityName);

            Console.WriteLine("Great job! You have completed the activity.");
            Console.WriteLine($"You spent {durationInSeconds} seconds on this activity.");
            ShowSpinner(3);
        }
    }
}
