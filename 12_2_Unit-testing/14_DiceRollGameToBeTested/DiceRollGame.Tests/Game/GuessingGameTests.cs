using System.Runtime;
using System.Security.Cryptography;
using ___;
using Game;
using Moq;
using UserCommunication;
using Xunit;

namespace DiceRollGame.Tests.Game;

public class GuessingGameTests
{
    private readonly Mock<IDice> _diceMock;
    private readonly Mock<IUserCommunication> _userCommunicationMock;
    private readonly GuessingGame _sut;

    public GuessingGameTests()
    {
        _diceMock = new Mock<IDice>();
        _userCommunicationMock = new Mock<IUserCommunication>();
        _sut = new GuessingGame(_diceMock.Object, _userCommunicationMock.Object);
    }
    
    [Fact]
    public void Play_ShallReturnVictory_IfTheUserGuessesTheNumberOnTheFirstTry()
    {
        const int NumbersOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumbersOnDie);

        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(NumbersOnDie);

        var gameResult = _sut.Play();
        
        Assert.Equal(GameResult.Victory, gameResult);
    }
    
    [Fact]
    public void Play_ShallReturnLoss_IfTheUserNeverGuessesTheNumber()
    {
        const int NumbersOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumbersOnDie);
        const int UserNumber = 1;
        _userCommunicationMock
            .Setup(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(UserNumber);

        var gameResult = _sut.Play();
        
        Assert.Equal(GameResult.Loss, gameResult);
    }
    
    [Fact]
    public void Play_ShallReturnVictory_IfTheUserGuessesTheNumberOnTheThirdTry()
    {
        const int NumbersOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumbersOnDie);

        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(NumbersOnDie);

        var gameResult = _sut.Play();
        
        Assert.Equal(GameResult.Victory, gameResult);
    }
    
    [Fact]
    public void Play_ShallReturnLoss_IfTheUserGuessesTheNumberOnTheFourthTry()
    {
        const int NumbersOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumbersOnDie);

        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(5)
            .Returns(NumbersOnDie);

        var gameResult = _sut.Play();
        
        Assert.Equal(GameResult.Loss, gameResult);
    }
    
    [Fact]
    public void Play_ShallShowWelcomeMessage()
    {
        var gameResult = _sut.Play();
        
        _userCommunicationMock.Verify(
            mock => mock.ShowMessage(GuessingGame.WelcomeMessage),
            Times.Once);
    }
    
    [Fact]
    public void Play_ShallAskForNumber_3_Times_IfTheUserGuessesTheNumberOnTheThirdTry()
    {
        const int NumbersOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumbersOnDie);

        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(NumbersOnDie);

        var gameResult = _sut.Play();

        _userCommunicationMock.Verify(
            mock => mock.ReadInteger(Resource.EnterNumberMessage),
            Times.Exactly(3));
    }
    
    [Fact]
    public void Play_ShallShowWrongNumber_2_Times_IfTheUserGuessesTheNumberOnTheThirdTry()
    {
        const int NumbersOnDie = 3;
        _diceMock
            .Setup(mock => mock.Roll())
            .Returns(NumbersOnDie);

        _userCommunicationMock
            .SetupSequence(mock => mock.ReadInteger(It.IsAny<string>()))
            .Returns(1)
            .Returns(2)
            .Returns(NumbersOnDie);

        var gameResult = _sut.Play();

        _userCommunicationMock.Verify(
            mock => mock.ShowMessage(Resource.WrongNumberMessage),
            Times.Exactly(2));
    }

    [Theory]
    [InlineData(GameResult.Victory, GuessingGame.VictoryMessage)]
    [InlineData(GameResult.Loss, GuessingGame.LossMessage)]
    public void PrintResult_ShallPrintAccordingMessage_BasedOnTheGameResult(GameResult gameResult, string message)
    {
        _sut.PrintResult(gameResult);

        _userCommunicationMock.Verify(mock => mock.ShowMessage(message));
    }
}