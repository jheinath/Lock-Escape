using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class IsSolvedTest
{
    [Fact]
    public void Create_NoInput_CreateIsSolvedCorrectly()
    {
        //Arrange + Act
        var result = IsSolved.Create();
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.Value.Should().BeFalse();
    }
}