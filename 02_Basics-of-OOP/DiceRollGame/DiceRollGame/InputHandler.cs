namespace DiceRollGame;

public static class InputHandler
{
    public static int GetValidGuess(int minValue, int maxValue)
    {
        if (minValue > maxValue)
        {
            throw new ArgumentException("minValue cannot be greater than maxValue");
        }
        
        int guess;
        bool isValid;
        
        do
        {
            Console.WriteLine($"Enter a number ({minValue}-{maxValue}):");
            isValid = int.TryParse(Console.ReadLine(), out guess) &&
                      guess >= minValue && guess <= maxValue;
            if (!isValid)
            {
                Console.WriteLine("Invalid number. Please try again.");
            }
        } while (!isValid);

        return guess;
    }
}