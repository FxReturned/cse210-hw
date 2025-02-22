using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        List<Activity> activities = new List<Activity>();

        Activity running = new Running(new DateTime(2022, 11, 03), 30, 3.0);

        Activity cycling = new Cycling(new DateTime(2022, 11, 03), 30, 20);

        Activity swimming = new Swimming(new DateTime(2022, 11, 03), 30, 25);

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
