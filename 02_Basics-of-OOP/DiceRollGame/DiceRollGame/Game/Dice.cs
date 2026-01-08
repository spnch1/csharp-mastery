namespace DiceRollGame.Game;

public class Dice(Random random, int sidesCount = 6)
{
    public int SidesCount => sidesCount;
    
    public int Roll() => random.Next(1, sidesCount + 1);
}
