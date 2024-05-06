using System;

namespace NumberGame
{
    internal class Program
    {
        private static  Random rand = new Random();
        private static int randomNumber;

        static void Main()
        {
            WelcomeScreen();
            RunGame(out int guesses);
            Console.WriteLine($"Congratulations, you got it in {guesses} guesses!"); // Display different result messages
            Console.ReadLine();
        }

        static void WelcomeScreen()
        {
            Console.WriteLine("Welcome to the number guessing game!");
            Console.WriteLine("Press any key to continue");
        }

        static void RunGame(out int numberOfGuesses)
        {
            randomNumber = rand.Next(0, 101);
            Console.WriteLine(randomNumber);
            int guess = -1;
            numberOfGuesses = 0;

            while (guess != randomNumber)
            {
                guess = GetGuess();
                numberOfGuesses += 1;
                AssessGuess(guess);
            }
        }

        private static void AssessGuess(int guess)
        {
            if (guess == randomNumber)
            {
                Console.WriteLine("You guessed correctly!");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine("Too low!");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine("Too high!");
            }
        }

        static int GetGuess()
        {
            while (true)
            {
                Console.WriteLine("Guess a number: ");
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.WriteLine("Please enter an integer.");
                }
                else
                {
                    return number;
                }
                Console.Clear();
            }

        }
    }
}

/*
TODO add difficulty level (greater range of numbers)
TODO display different success message depending on guesses and difficulty
 */
