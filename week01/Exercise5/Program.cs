using System;

class Program
{    
    static void Main(string[] args)
    {
        WelcomeMessage();

        string Name = PromptName();
        int Number = PromptNumber();

        int squaredNumber = SquareNumber(Number);

        DisplayResult(Name, squaredNumber);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptName()
    {
        Console.Write("Please enter your name: ");
        string promptName = Console.ReadLine();

        return promptName;
    }

    static int PromptNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int promptNumber = int.Parse(Console.ReadLine());

        return promptNumber;
    }

    static int SquareNumber(int promptNumber)
    {
        int square = promptNumber * promptNumber;
        return square;
    }

    static void DisplayResult(string promptName, int square)
    {
        Console.WriteLine($"{promptName}, the square of your number is {square}");
    }
}