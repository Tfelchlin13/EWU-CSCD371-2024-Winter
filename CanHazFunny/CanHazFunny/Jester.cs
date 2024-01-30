using System;

namespace CanHazFunny;

public class Jester(IJokeService jokeService, IJokeOutput jokeOutput)
{
    IJokeService _JokeService { get; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
    IJokeOutput _JokeOutput { get; } = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));

    public void TellJoke()
    {
        string joke;
        do
        {
            joke = _JokeService.GetJoke();
        } while (joke.Contains("Chuck Norris"));

        _JokeOutput.WriteJoke(joke);
    }
}

