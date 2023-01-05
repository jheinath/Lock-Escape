using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class GameSolutionTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_EmptyInput_ReturnsGameSolutionMustNotBeEmptyError(string input)
    {
        //Arrange
        var expectedError = new GameSolutionMustNotBeEmptyError();
        
        //Act
        var result = GameSolution.Create(input);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().BeEquivalentTo(new List<Error> { expectedError });
    }

    [Fact]
    public void Create_ValidInput_CreatesCorrectly()
    {
        //Arrange
        const string input = "Test123";
        
        //Act
        var result = GameSolution.Create(input);
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be(input);
    }
}