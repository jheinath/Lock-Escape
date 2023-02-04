using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.Test.EscapeGames.ValueObjects;

public class IsSelectedTest
{
    [Fact]
    public void Create_NoInput_CreateIsSelectedCorrectly()
    {
        //Arrange + Act
        var result = IsSelected.Create();
        
        //Assert
        result.Errors.Should().BeEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Value.Value.Should().BeFalse();
    }
}