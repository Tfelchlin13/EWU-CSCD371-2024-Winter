using System;

namespace CanHazFunny;

public class JokeOutput : IJokeOutput
{
    public void WriteJoke(string joke)
    {
        ArgumentNullException.ThrowIfNull(joke);

        Console.WriteLine(joke);
    }
}

