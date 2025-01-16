using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        int guessnumber = -1;
        int tries = 1;

        while (guessnumber != magicNumber)
        {
            Console.Write("What is your guess? ");
            guessnumber = int.Parse(Console.ReadLine());

            if (magicNumber > guessnumber)
            {
                Console.WriteLine("Higher");
                tries += 1;
            }
            else if (magicNumber < guessnumber)
            {
                Console.WriteLine("Lower");
                tries += 1;
            }
            else
            {
                Console.WriteLine("You got it!");
                Console.WriteLine($"Your number of attempts was {tries}!");
            }


        }                 
    }
}