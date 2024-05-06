using System;

namespace NumberGame
{
    internal class Program
    {
        private static Random rand = new Random();
        private static int randomNumber;
        static void Main()
        {
            WelcomeScreen();
            int guesses = RunGame();
            Console.WriteLine($"Congratulation, you got it in {guesses} guess!");
            Console.ReadLine();
        }
        static void WelcomeScreen()
        {
            Console.WriteLine("Welcome to the number guessing game!");
            Console.WriteLine("Press any key to continue");
        }
        static int RunGame()
        {
            randomNumber = rand.Next(0, 1001);
            int guess;
            int numberOfGuesses = 0;

            while (true)
            {
                guess = GetGuess();
                numberOfGuesses += 1;
                if (guess == randomNumber)
                {
                    Console.WriteLine("You guessed correctly!");
                    return numberOfGuesses;
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
        }
        static int GetGuess()
        {
            int number;
            while (true)
            {
                Console.WriteLine("Guess a number: ");
                if (!int.TryParse(Console.ReadLine(), out number))
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
 Welcome user and begin game
        TODO add difficulty level
Prompt for guess
Say if high or low
        TODO say if way too high/low depending on difficulty
        TODO number range greater on higher difficulties
Congratulate on correct guess
Ask if play again



 */
