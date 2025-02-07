using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity()
        {
            activityName = "Breathing Activity";
            activityDescription = "This activity will help you relax by guiding you through deep breathing. Focus on your breath.";
        }

        public override void StartActivity()
        {
            base.StartActivity();

            int elapsed = 0;
            while (elapsed < durationInSeconds)
            {
                Console.Clear();
                Console.WriteLine("Breathe in...");
                ShowCountdown(4);  
                elapsed += 4;
                if (elapsed >= durationInSeconds)
                    break;

                Console.Clear();
                Console.WriteLine("Breathe out...");
                ShowCountdown(4);  
                elapsed += 4;
            }

            EndActivity();
        }
    }
}
