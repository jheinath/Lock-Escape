using Domain.EscapeGames.Entities;
using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.Test.EscapeGames.Entities;

public class RiddleTest
{
    [Fact]
    public void Create_ValidInput_CreatesRiddleCorrectly()
    {
        //Arrange
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create().Value;
        
        //Act
        var result = Riddle.Create(riddleSolution, isSolved);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.IsSolved.Should().BeEquivalentTo(isSolved);
        result.Value.RiddleSolution.Should().BeEquivalentTo(riddleSolution);
    }
}