using Domain.EscapeGames.ValueObjects;
using Domain.Test.Lib;
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
        result.Should().BeSuccessfulWithoutErrors();
        result.Value.Value.Should().BeFalse();
    }
}