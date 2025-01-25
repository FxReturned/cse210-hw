using System;
using System.Collections.Generic;

class Joke
{
  public static string GetRandomJoke()
  {
    List<string> jokes = new List<string>
        {
            "Why don't skeletons fight each other? They don't have the guts.",
            "Why couldn't the bicycle stand up by itself? It was two tired.",
            "What do you call cheese that isn't yours? Nacho cheese.",
            "Why don't eggs tell jokes? They'd crack each other up.",
            "What do you call fake spaghetti? An impasta!"
        };

    Random random = new Random();
    int index = random.Next(jokes.Count);
    return jokes[index];
  }
}