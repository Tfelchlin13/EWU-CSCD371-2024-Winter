﻿using System;

namespace CanHazFunny;

public class Program
{
   public static void Main(string[] args)
    {
        //Feel free to use your own setup here - this is just provided as an example
        //new Jester(new SomeReallyCoolOutputClass(), new SomeJokeServiceClass()).TellJoke();
        IJokeService jokeService = new JokeService();
        IJokeOutput jokeOutput = new JokeOutput();

        // Create an instance of the Jester class
        Jester jester = new (jokeService, jokeOutput);

        // Tell a joke
        Console.WriteLine("Here's a joke from the Jester:");
        jester.TellJoke();
    }
}