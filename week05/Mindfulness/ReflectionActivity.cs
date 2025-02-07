using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different from others?",
            "What is your favorite aspect of this experience?",
            "What could you learn from this experience for future challenges?",
            "What did you learn about yourself from this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectionActivity()
        {
            activityName = "Reflection Activity";
            activityDescription = "This activity will help you reflect on times when you have shown strength and resilience. Consider a meaningful experience.";
        }

        public override void StartActivity()
        {
            base.StartActivity();

            // Choose a random prompt
            Random random = new Random();
            string chosenPrompt = prompts[random.Next(prompts.Count)];
            Console.Clear();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine(chosenPrompt);
            Console.WriteLine("When you're ready, press Enter to continue...");
            Console.ReadLine();

            Console.WriteLine("Now, reflect on the following questions:");
            int elapsed = 0;
            while (elapsed < durationInSeconds)
            {
                string question = questions[random.Next(questions.Count)];
                Console.WriteLine(question);
                ShowSpinner(5);  
                elapsed += 5;
            }

            EndActivity();
        }
    }
}
