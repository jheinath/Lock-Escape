using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
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
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().BeEquivalentTo(new List<Error> { expectedError });
    }

    [Fact]
    public void Create_ValidInput_CreatesCorrectly()
    {
        //Arrange
        const int input = 1;
        
        //Act
        var result = GroupNumber.Create(input);
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Value!.Value.Should().Be(input);
    }
}