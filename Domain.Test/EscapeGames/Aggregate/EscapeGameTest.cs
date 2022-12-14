using System.Globalization;
using Domain.EscapeGames.Aggregate;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using FluentAssertions;
using FluentResults;
using Xunit;

namespace Domain.Test.EscapeGames.Aggregate;

public class EscapeGameTest
{
    private readonly CreatorPassword _defaultCreatorPassword;

    public EscapeGameTest()
    {
        _defaultCreatorPassword = CreatorPassword.Create("PasswordIsABadPassword").Value;
    }
    
    [Fact]
    public void Create_InvalidCultureInput_ReturnInvalidCultureError()
    {
        //Arrange
        var expectedError = new InvalidCultureError();
        
        //Act
        var result = EscapeGame.Create(null!, new List<Riddle>(), new List<GameSolutionForGroup>(), _defaultCreatorPassword);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().BeEquivalentTo(new List<Error>() { expectedError });
    }
    
    [Fact]
    public void Create_EmptyListOfRiddles_ReturnRiddlesMustNotBeEmptyError()
    {
        //Arrange
        var expectedError = new RiddlesMustNotBeEmptyError();
        
        //Act
        var result = EscapeGame.Create("de-DE", new List<Riddle>(), new List<GameSolutionForGroup>(), _defaultCreatorPassword);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainEquivalentOf(expectedError);
    }
    
    [Fact]
    public void Create_EmptyListOfGameSolutionForGroups_ameSolutionForGroupsMustNotBeEmptyError()
    {
        //Arrange
        var expectedError = new GameSolutionForGroupsMustNotBeEmptyError();
        
        //Act
        var result = EscapeGame.Create("de-DE", new List<Riddle>(), new List<GameSolutionForGroup>(), _defaultCreatorPassword);
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainEquivalentOf(expectedError);
    }

    [Fact]
    public void Create_ValidInput_CreatesEscapeGameCorrectly()
    {
        //Arrange
        const string culture = "de-DE";
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create().Value;
        var riddle = Riddle.Create(riddleSolution, isSolved).Value;
        var gameSolution = GameSolution.Create("SolutionPhrase 123").Value;
        var groupNumber = GroupNumber.Create(2).Value;
        var gameSolutionForGroup = GameSolutionForGroup.Create(groupNumber, gameSolution).Value;
        
        //Act
        var result = EscapeGame.Create(culture, new[] { riddle }, new []{ gameSolutionForGroup }, _defaultCreatorPassword);
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.CultureInfo.Should().BeEquivalentTo(new CultureInfo(culture));
        result.Value.Riddles.Should().BeEquivalentTo(new[] { riddle });
        result.Value.GameSolutionForGroups.Should()
            .BeEquivalentTo(new List<GameSolutionForGroup> { gameSolutionForGroup });
        result.Value.CreatorPassword.Should().Be(_defaultCreatorPassword);
    }
}