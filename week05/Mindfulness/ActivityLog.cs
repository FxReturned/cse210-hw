using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public static class ActivityLog
    {
        private static Dictionary<string, int> log = new Dictionary<string, int>();

        public static void LogActivity(string activityName)
        {
            if (log.ContainsKey(activityName))
            {
                log[activityName]++;
            }
            else
            {
                log[activityName] = 1;
            }
        }

        public static void DisplayLog()
        {
            Console.Clear();
            Console.WriteLine("=== Activity Log ===");
            if (log.Count == 0)
            {
                Console.WriteLine("No activities completed yet.");
            }
            else
            {
                foreach (var entry in log)
                {
                    Console.WriteLine($"{entry.Key}: {entry.Value} time(s)");
                }
            }
            Console.WriteLine("====================");
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
