using DiceRollGame;

const int minRolledValue = 1;
const int maxRolledValue = 6;
const int maxAmountOfTries = 3;

var rolledNumber = NumberRoller.Roll(minRolledValue, maxRolledValue);

Console.WriteLine($"Dice rolled. Guess what number it shows in {maxAmountOfTries} tries.");

var curAmountOfTries = 0;

do
{
    var guessedNumber = InputHandler.GetValidGuess(minRolledValue, maxRolledValue);
    if (guessedNumber == rolledNumber)
    {
        Console.WriteLine("You win!");
        break;
    }
    
    Console.WriteLine("Wrong number");
    ++curAmountOfTries;
} while (curAmountOfTries < maxAmountOfTries);

if (curAmountOfTries == maxAmountOfTries)
    Console.WriteLine("You lose :(");

Console.WriteLine("Press any key to exit. . .");
Console.ReadLine();