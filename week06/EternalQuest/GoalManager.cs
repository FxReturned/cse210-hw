using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _score;
        private int _currentStreak;
        private int _currentLevel;

        public GoalManager()
        {
            _goals = new List<Goal>();
            _score = 0 ;
            
            _currentLevel = GetLevel();
        }

        private int GetLevel()
        {
            if (_score < 100)
                return 1;
            else if (_score < 250)
                return 2;
            else if (_score < 500)
                return 3;
            else if (_score < 1000)
                return 4;
            else
                return 5;
        }

        public void Start()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Eternal Quest Program ---");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. Save Goals");
                Console.WriteLine("5. Load Goals");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateGoal();
                        break;
                    case "2":
                        ListGoalDetails();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        SaveGoals();
                        break;
                    case "5":
                        LoadGoals();
                        break;
                    case "6":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                if (choice == "5")
                {
                    _currentStreak = 0;
                    Console.WriteLine("The Points were reset");
                }
            }
        }

        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Current Score: {_score} | Level: {_currentLevel}");
        }

        public void ListGoalNames()
        {
            Console.WriteLine("Goals:");
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetShortName()}");
                index++;
            }
        }

        public void ListGoalDetails()
        {
            Console.WriteLine("\nGoal Details:");
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetDetailsString()}");
                index++;
            }
            DisplayPlayerInfo();
        }

        public void CreateGoal()
        {
            Console.WriteLine("\nSelect Goal Type:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter the goal's short name: ");
            string shortName = Console.ReadLine();
            Console.Write("Enter the goal's description: ");
            string description = Console.ReadLine();
            Console.Write("Enter the points for the goal: ");
            int points;
            while (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.Write("Invalid input. Enter a numeric value for points: ");
            }

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(shortName, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(shortName, description, points));
                    break;
                case "3":
                    Console.Write("Enter the target number of completions: ");
                    int target;
                    while (!int.TryParse(Console.ReadLine(), out target))
                    {
                        Console.Write("Invalid input. Enter a numeric value for target: ");
                    }
                    Console.Write("Enter the bonus points for completing the goal: ");
                    int bonus;
                    while (!int.TryParse(Console.ReadLine(), out bonus))
                    {
                        Console.Write("Invalid input. Enter a numeric value for bonus: ");
                    }
                    _goals.Add(new ChecklistGoal(shortName, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type selected.");
                    break;
            }
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record an event.");
                return;
            }

            Console.WriteLine("\nSelect the goal for which you want to record an event:");
            ListGoalNames();
            Console.Write("Enter the number of the goal: ");
            int choice;
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= _goals.Count)
            {
                Goal selectedGoal = _goals[choice - 1];
                int basePoints = selectedGoal.RecordEvent();
                if (basePoints > 0)
                {
                    _currentStreak++;
                    int streakBonus = _currentStreak * 5;
                    int totalPoints = basePoints + streakBonus;
                    _score += totalPoints;
                    Console.WriteLine($"Event recorded. Base points: {basePoints}. Streak bonus: {streakBonus} (Streak: {_currentStreak}). Total points earned: {totalPoints}");

                    int newLevel = GetLevel();
                    if (newLevel > _currentLevel)
                    {
                        _currentLevel = newLevel;
                        Console.WriteLine($"Congratulations! You've leveled up to Level {_currentLevel}!");
                    }
                }
                else
                {
                    Console.WriteLine("No points earned for this event.");
                }
            }
            else
            {
                Console.WriteLine("Invalid goal selection.");
            }
        }

        public void SaveGoals()
        {
            Console.Write("Enter the filename to save goals: ");
            string filename = Console.ReadLine();
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.WriteLine(_score);
                    foreach (Goal goal in _goals)
                    {
                        writer.WriteLine(goal.GetStringRepresentation());
                    }
                }
                Console.WriteLine("Goals saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving goals: {ex.Message}");
            }
        }

        public void LoadGoals()
        {
            Console.Write("Enter the filename to load goals: ");
            string filename = Console.ReadLine();
            try
            {
                if (File.Exists(filename))
                {
                    using (StreamReader reader = new StreamReader(filename))
                    {
                        _goals.Clear();
                        string scoreLine = reader.ReadLine();
                        int.TryParse(scoreLine, out _score);
                        _currentStreak = 0;
                        _currentLevel = GetLevel();
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(';');
                            if (parts.Length > 0)
                            {
                                string goalType = parts[0];
                                if (goalType == "SimpleGoal" && parts.Length == 5)
                                {
                                    string shortName = parts[1];
                                    string description = parts[2];
                                    int points = int.Parse(parts[3]);
                                    bool isComplete = bool.Parse(parts[4]);
                                    SimpleGoal sg = new SimpleGoal(shortName, description, points);
                                    if (isComplete)
                                    {
                                        sg.RecordEvent();
                                    }
                                    _goals.Add(sg);
                                }
                                else if (goalType == "EternalGoal" && parts.Length == 4)
                                {
                                    string shortName = parts[1];
                                    string description = parts[2];
                                    int points = int.Parse(parts[3]);
                                    EternalGoal eg = new EternalGoal(shortName, description, points);
                                    _goals.Add(eg);
                                }
                                else if (goalType == "ChecklistGoal" && parts.Length == 7)
                                {
                                    string shortName = parts[1];
                                    string description = parts[2];
                                    int points = int.Parse(parts[3]);
                                    int amountCompleted = int.Parse(parts[4]);
                                    int target = int.Parse(parts[5]);
                                    int bonus = int.Parse(parts[6]);
                                    ChecklistGoal cg = new ChecklistGoal(shortName, description, points, target, bonus);
                                    for (int i = 0; i < amountCompleted; i++)
                                    {
                                        cg.RecordEvent();
                                    }
                                    _goals.Add(cg);
                                }
                            }
                        }
                    }
                    Console.WriteLine("Goals loaded successfully.");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
    }
}
