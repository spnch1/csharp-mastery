using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game;

public class GuessingGame(Dice dice, int initialTries = 3)
{
    public int InitialTries => initialTries;
    
    public GameResult Play()
    {
        var diceRollResult = dice.Roll();
        Console.WriteLine($"Dice rolled. Guess what number it shows in {initialTries} tries.");

        var triesRemaining = initialTries;
        while (triesRemaining > 0)
        {
            var guess = ConsoleReader.ReadInt($"Enter a number (1-{dice.SidesCount}):");
            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }

            Console.WriteLine("Wrong number.");
            --triesRemaining;
        }

        return GameResult.Loss;
    }

    public static void PrintResult(GameResult gameResult)
    {
        var message = gameResult == GameResult.Victory ? "You win!" : "You lose :(";
        Console.WriteLine(message);
    }
}