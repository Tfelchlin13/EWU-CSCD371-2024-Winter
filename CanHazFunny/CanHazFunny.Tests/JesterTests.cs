using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using System;
using Xunit;

namespace CanHazFunny.Tests;

public class JesterTests
{
    public Mock<IJokeService> JokeServiceMock { get; }
    public Mock<IJokeOutput> JokeOutputMock { get; }
    public Jester JesterInstance { get; }
    public JesterTests()
    {
        JokeServiceMock = new Mock<IJokeService>();
        JokeOutputMock = new Mock<IJokeOutput>();
        JesterInstance = new Jester(JokeServiceMock.Object, JokeOutputMock.Object);
    }
    [Fact]
    public void JokeOutput_Joke_WriteToConsole()
    {
    
        Mock<IJokeOutput> jokeOutputMock = new();
        string expectedJoke = "This is a super funny joke!";

        
        jokeOutputMock.Object.WriteJoke(expectedJoke);

        jokeOutputMock.Verify(jokeoutput => jokeoutput.WriteJoke(expectedJoke), Times.Once);
    }
    [Fact]
    public void JokeService_Joke_Success()
    {
        Mock<IJokeService> jokeServiceMock = new Mock<IJokeService>();
        string expectedJoke = "This is a super funny joke!";
        jokeServiceMock.Setup(jokeservice => jokeservice.GetJoke()).Returns(expectedJoke);

        string result = jokeServiceMock.Object.GetJoke();

        Assert.Equal(expectedJoke, result);
    }
    [Fact]
    public void Constructor_NullJokeService_ThrowsArgumentNullException()
    {
        IJokeService nullJokeService = null!;
        IJokeOutput mockJokeOutput = Mock.Of<IJokeOutput>();

        Assert.Throws<ArgumentNullException>(() => new Jester(nullJokeService, mockJokeOutput));
    }

    [Fact]
    public void Constructor_NullJokeOutput_ThrowsArgumentNullException()
    {
        IJokeService mockJokeService = Mock.Of<IJokeService>();
        IJokeOutput nullJokeOutput = null!;

        Assert.Throws<ArgumentNullException>(() => new Jester(mockJokeService, nullJokeOutput));
    }

    [Fact]
    public void Constructor_NullJokeServiceAndJokeOutput_ThrowsArgumentNullException()
    {
        IJokeService nullJokeService = null!;
        IJokeOutput nullJokeOutput = null!;

        Assert.Throws<ArgumentNullException>(() => new Jester(nullJokeService, nullJokeOutput));
    }
    [Fact]
    public void TellJoke_ChuckNorrisJoke_PrintsAndSkipsChuckNorrisJoke()
    {
        
        JokeServiceMock.SetupSequence(jokeservice => jokeservice.GetJoke())
            .Returns("Chuck Norris is the goat!")
            .Returns("This is a super amazing joke");

        JesterInstance.TellJoke();

        JokeOutputMock.Verify(jokeoutput => jokeoutput.WriteJoke("This is a super amazing joke"), Times.Once);
    }
    [Fact]
    public void TellJoke_NonChuckNorrisJoke_PrintJoke()
    {
        JokeServiceMock.Setup(jokeservice => jokeservice.GetJoke()).Returns("This is a super amazing joke");

        JesterInstance.TellJoke();

        JokeOutputMock.Verify(jokeoutput => jokeoutput.WriteJoke("This is a super amazing joke"), Times.Once);
    }
}
