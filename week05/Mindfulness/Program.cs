//This program exceeds requirements by including an activity log that tracks how many times each exercise is performed, offering users valuable feedback on their mindfulness practice.
using System;

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Mindfulness Program ===");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Activity Log");
                Console.WriteLine("5. Quit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                MindfulnessActivity activity = null;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        ActivityLog.DisplayLog();
                        continue; 
                    case "5":
                        running = false;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        continue;
                }

                if (activity != null)
                {
                    activity.StartActivity();
                }

                Console.WriteLine("Press any key to return to the main menu...");
                Console.ReadKey();
            }
        }
    }
}
