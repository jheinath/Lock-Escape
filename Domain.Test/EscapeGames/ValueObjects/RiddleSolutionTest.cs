using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class RiddleSolutionTest
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    public void Create_InputIsNullOrEmpty_ReturnsRiddleSolutionsMustNotBeEmptyError(string inputValue)
    {
        //Arrange
        var expectedError = new RiddleSolutionMustNotBeEmptyError();
        
        //Act
        var result = RiddleSolution.Create(inputValue);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainEquivalentOf(expectedError);
    }
    
    [Fact]
    public void Create_InputIsNotOnlyDigits_ReturnsRiddleSolutionsMustNotBeEmptyError()
    {
        //Arrange
        var expectedError = new RiddleSolutionInvalidFormatError();
        
        //Act
        var result = RiddleSolution.Create("A12");
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainEquivalentOf(expectedError);
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("22")]
    [InlineData("4444")]
    public void Create_InvalidLength_ReturnsRiddleSolutionInvalidLengthError(string inputValue)
    {
        //Arrange
        var expectedError = new RiddleSolutionInvalidLengthError(3);
        
        //Act
        var result = RiddleSolution.Create(inputValue);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainEquivalentOf(expectedError);
    }

    [Fact]
    public void Create_ValidInput_CreateRiddleSolutionCorrectly()
    {
        //Arrange
        const string input = "245";
        
        //Act
        var result = RiddleSolution.Create(input);
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.Value.Should().Be(input);
    }
}