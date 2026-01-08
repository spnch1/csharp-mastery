namespace DiceRollGame;

public static class NumberRoller
{
     public static int Roll(int minValue, int maxValue) =>
          Random.Shared.Next(minValue, maxValue + 1);
}