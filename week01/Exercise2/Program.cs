using System;
using System.Reflection.Metadata;

class Program
{
    static void Main(string[] args)
    {
Console.Write("What is your grade percentage? ");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);
        int lastdigit = percent % 10;

        string letter = "";
        string sign = "";

        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

     
        if (lastdigit >= 7 && letter != "A" && letter != "F")
        {
             sign = "+";
        }
        else if (lastdigit < 3 && letter != "F")
        {
             sign = "-";
        }
        


        Console.WriteLine($"Your grade is: {letter}{sign}");
        
        if (percent >= 70)
        {
            Console.WriteLine("You passed! Good Job!");
        }
        else
        {
            Console.WriteLine("try harder next time!");
        }
    }
}