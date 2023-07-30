using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using Domain.Test.Lib;
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
        result.Errors.Should().BeSingleErrorListWith(expectedError);
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void Create_ValidInput_CreatesCorrectly()
    {
        //Arrange
        const string input = "Test123";
        
        //Act
        var result = GameSolution.Create(input);
        
        //Assert
        result.Should().BeSuccessfulWithoutErrors();
        result.Value.Value.Should().Be(input);
    }
}