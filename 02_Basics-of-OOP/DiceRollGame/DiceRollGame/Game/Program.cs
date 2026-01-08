using DiceRollGame.Game;

Random random = new();
Dice dice = new(random);
GuessingGame guessingGame = new(dice);

var gameResult = guessingGame.Play();
GuessingGame.PrintResult(gameResult);

Console.ReadKey(true);