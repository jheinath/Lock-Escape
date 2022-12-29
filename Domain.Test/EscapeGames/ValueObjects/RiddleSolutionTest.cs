using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class RiddleSolutionTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_InvalidInput_ReturnsRiddleSolutionsMustNotBeEmptyError(string inputValue)
    {
        //Arrange
        var expectedError = new RiddleSolutionInvalidLengthError(3);
        
        //Act
        var result = RiddleSolution.Create(inputValue);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainEquivalentOf(expectedError);
    }
}