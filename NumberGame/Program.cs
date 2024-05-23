using System;

namespace NumberGame
{
    internal class Program
    {
        private static Random rand = new Random();
        private static int randomNumber;
        private static int lowestClose = -1;
        private static int highestClose = int.MaxValue;

        static void Main()
        {
            WelcomeScreen();
            RunGame(out int guesses);
            Console.WriteLine($"Congratulations, you got it in {guesses} guesses!");
            Console.ReadLine();
        }

        static void WelcomeScreen()
        {
            Console.WriteLine("Welcome to the number guessing game!");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        static void RunGame(out int numberOfGuesses)
        {
            //Console.Clear();
            randomNumber = rand.Next(0, 101);
            int guess = -1;

            numberOfGuesses = 0;

            while (guess != randomNumber)
            {
                Console.Clear();
                Console.WriteLine(randomNumber); // TESTING ONLY
                DisplayPreviousGuesses();
                guess = GetGuess();
                numberOfGuesses += 1;
                TooHighTooLow(guess);

                if (guess > lowestClose && guess < randomNumber)
                {
                    lowestClose = guess;
                }

                if (guess < highestClose && guess > randomNumber)
                {
                    highestClose = guess;
                }
            }
        }

        private static void TooHighTooLow(int guess)
        {
            if (guess == -1){}
            else if (guess < randomNumber)
            {
                Console.WriteLine($"{guess} is too low!");
            }
            else if (guess > randomNumber)
            {
                Console.WriteLine($"{guess} is too high!");
            }
        }

        static int GetGuess()
        {
            Console.WriteLine("Please enter a number: ");
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out int number))
                {
                    Console.Clear();
                    DisplayPreviousGuesses();
                    Console.WriteLine("Please enter an integer.");
                }
                else
                {
                    return number;
                }

            }

        }

        static void DisplayPreviousGuesses()
        {
            bool lowestSet = lowestClose != -1;
            bool highestSet = highestClose != int.MaxValue;

            if (lowestSet && highestSet)
            {
                Console.WriteLine($"You know the number is between {lowestClose} and {highestClose}");
            }
            else if (lowestSet)
            {
                Console.WriteLine($"You know the number is greater than {lowestClose}");
            }
            else if (highestSet)
            {
                Console.WriteLine($"You know the number is less than {highestClose}");
            }
        }
    }
}


