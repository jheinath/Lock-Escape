using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using Domain.Test.Lib;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class CreatorPasswordTest
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void Create_EmptyInput_ReturnsCreatorPasswordMustNotBeEmptyError(string input)
    {
        //Arrange
        var expectedError = new CreatorPasswordMustNotBeEmptyError();
        
        //Act
        var result = CreatorPassword.Create(input);
        
        //Assert
        result.Errors.Should().BeSingleErrorListWith(expectedError);
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void Create_ValidInput_CreatesCorrectly()
    {
        //Arrange
        const string input = "123456789 - is a bad password";
        
        //Act
        var result = CreatorPassword.Create(input);
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().Be(input);
    }
}