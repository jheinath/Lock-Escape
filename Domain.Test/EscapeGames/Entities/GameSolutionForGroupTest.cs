using Domain.EscapeGames.Entities;
using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Domain.Test.EscapeGames.Entities;

public class GameSolutionForGroupTest
{
    [Fact]
    public void Create_ValidInput_CreatesCorrectly()
    {
        //Arrange
        var gameSolution = GameSolution.Create("SolutionPhrase 123").Value;
        var groupNumber = GroupNumber.Create(2).Value;
        
        //Act
        var result = GameSolutionForGroup.Create(groupNumber, gameSolution);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.GameSolution.Should().BeEquivalentTo(gameSolution);
        result.Value.GroupNumber.Should().BeEquivalentTo(groupNumber);
    }
}