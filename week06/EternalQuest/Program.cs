using System;

namespace EternalQuest
{
    // Creative Enhancements:
    // 1. Level System: The player levels up based on their total score.
    //    Levels are defined by score thresholds and the user is congratulated when they level up.
    // 2. Streak System: Consecutive event records grant a bonus. Each successive event in a streak adds extra bonus points.
    class Program
    {
        static void Main(string[] args)
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}
