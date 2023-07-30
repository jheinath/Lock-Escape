using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using Domain.Test.Lib;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class GroupNumberTest
{
    [Theory]
    [InlineData(-1)]
    [InlineData(-100)]
    [InlineData(0)]
    public void Create_NegativeInput_ReturnsGroupNumberMustBeAtLeastOneError(int input)
    {
        //Arrange
        var expectedError = new GroupNumberMustBeAtLeastOneError();
        
        //Act
        var result = GroupNumber.Create(input);
        
        //Assert
        
        result.Errors.Should().BeSingleErrorListWith(expectedError);
        result.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void Create_ValidInput_CreatesCorrectly()
    {
        //Arrange
        const int input = 1;
        
        //Act
        var result = GroupNumber.Create(input);
        
        //Assert
        result.Should().BeSuccessfulWithoutErrors();
        result.Value!.Value.Should().Be(input);
    }
}