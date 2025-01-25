using System;
class Program
{
    static void Main (string[] args)
    {
        Option option = new Option();
        bool isRunning = true;

        while ( isRunning )
        {
            Console.WriteLine("\nWelcome to te Journal Program! \nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");

            Console.Write("Select an option (1-5): ");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    string prompt = Prompt.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Enter your response: ");
                    string response = Console.ReadLine();
                    option.AddEntry(prompt, response);
                    break;

                case "2":
                    if ( option.EntriesCount() == 0 )
                        {
                            Console.WriteLine("The journal is empty. Add some entries first.");
                        }
                    else
                        {
                            option.DisplayEntries();
                        }
                    break;

                case "3":
                    Console.Write("Enter the file name to save: ");
                    string saveFileName = Console.ReadLine();
                    option.SaveToFile(saveFileName);
                    Console.WriteLine("Journal saved successfully.");
                    break;

                case "4":
                    Console.Write("Enter the file name to load: ");
                    string loadFileName = Console.ReadLine();
                    option.LoadFromFile(loadFileName);
                    Console.WriteLine("Journal loaded successfully.");
                    break;

                case "5":
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Incorrect choice. Please select a valid option (1-5).");
                    break;    
            }

        }
    }
}