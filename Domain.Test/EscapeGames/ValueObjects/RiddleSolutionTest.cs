using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using Domain.Test.Lib;
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
        result.Errors.Should().ContainEquivalentOf(expectedError);
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void Create_InputIsNotOnlyDigits_ReturnsRiddleSolutionsMustNotBeEmptyError()
    {
        //Arrange
        var expectedError = new RiddleSolutionInvalidFormatError();
        
        //Act
        var result = RiddleSolution.Create("A12");
        
        //Assert
        result.Errors.Should().BeSingleErrorListWith(expectedError);
        result.IsFailed.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("1")]
    [InlineData("22")]
    [InlineData("44442")]
    public void Create_InvalidLength_ReturnsRiddleSolutionInvalidLengthError(string inputValue)
    {
        //Arrange
        var expectedError = new RiddleSolutionInvalidLengthError(3);
        
        //Act
        var result = RiddleSolution.Create(inputValue);
        
        //Assert
        result.Errors.Should().BeSingleErrorListWith(expectedError);
        result.IsFailed.Should().BeTrue();
    }
    
    [Theory]
    [InlineData("165")]
    [InlineData("2226")]
    public void Create_ValidInput_CreateRiddleSolutionCorrectly(string inputValue)
    {
        //Act
        var result = RiddleSolution.Create(inputValue);
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.Value.Should().Be(inputValue);
    }
}