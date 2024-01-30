using System;

namespace CanHazFunny
{
    public class Jester(IJokeService jokeService, IJokeOutput jokeOutput)
    {
        IJokeService JokeService { get; } = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        IJokeOutput JokeOutput { get; } = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));

        public void TellJoke()
        {
            string joke;
            do
            {
                joke = JokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));

            JokeOutput.WriteJoke(joke);
        }
    }
}
