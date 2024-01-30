using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny;

    public class Jester(IJokeService jokeService, IJokeOutput jokeOutput)
    {
        private readonly IJokeService _jokeService = jokeService ?? throw new ArgumentNullException(nameof(jokeService));
        private readonly IJokeOutput _jokeOuput = jokeOutput ?? throw new ArgumentNullException(nameof(jokeOutput));


        public void TellJoke()
        {
            string joke;
            do
            {
                joke = jokeService.GetJoke();
            } while (joke.Contains("Chuck Norris"));

            jokeOutput.WriteJoke(joke);
        }

    }
    

