using System.Runtime.Versioning;
using ___;
using UserCommunication;

namespace Game;

public class GuessingGame
{
    private readonly IDice _dice;
    private readonly IUserCommunication _userCommunication;
    private const int InitialTries = 3;
    public static readonly string WelcomeMessage = $"Dice rolled. Guess what number it shows in {InitialTries} tries.";
    public const string VictoryMessage = "You win!";
    public const string LossMessage = "You lose :(";

    public GuessingGame(
        IDice dice,
        IUserCommunication userCommunication)
    {
        _dice = dice;
        _userCommunication = userCommunication;
    }

    public GameResult Play()
    {
        var diceRollResult = _dice.Roll();
        _userCommunication.ShowMessage(WelcomeMessage);

        var triesLeft = InitialTries;
        while (triesLeft > 0)
        {
            var guess = _userCommunication.ReadInteger(Resource.EnterNumberMessage);
            if (guess == diceRollResult)
            {
                return GameResult.Victory;
            }
            _userCommunication.ShowMessage(Resource.WrongNumberMessage);
            --triesLeft;
        }
        return GameResult.Loss;
    }

    public void PrintResult(GameResult gameResult)
    {
        var message = gameResult == GameResult.Victory
            ? Resource.VictoryMessage
            : Resource.LossMessage;

        _userCommunication.ShowMessage(message);
    }
}
