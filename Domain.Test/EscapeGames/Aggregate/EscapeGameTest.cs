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
        result.Value.SelectedGroupNumber.Should().BeNull();
    }

    [Fact]
    public void SelectGroupNumber_ValueOutOfRange_ReturnsError()
    {
        //Arrange
        var escapeGame = CreateValidEscapeGame();
        var groupNumber = GroupNumber.Create(15).Value;
        
        //Act
        var result = EscapeGame.SelectGroupNumber(escapeGame, groupNumber);
        
        //Assert
        result.Errors.Should().BeEquivalentTo(new List<Error> { new SelectGroupNumberIsNotAvailableError() });
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void SelectGroupNumber_ValidSelection_ReturnsUpdatedAggregate()
    {
        //Arrange
        var escapeGame = CreateValidEscapeGame();
        var groupNumber = GroupNumber.Create(2).Value;
        
        //Act
        var result = EscapeGame.SelectGroupNumber(escapeGame, groupNumber);
        
        //Assert
        result.Errors.Should().BeEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(escapeGame, options => options.Excluding(x => x.SelectedGroupNumber));
        result.Value.SelectedGroupNumber.Value.Should().Be(2);
    }

    [Fact]
    public void SolveRiddle_NonExistingRiddle_ReturnsRiddleNotFoundError()
    {
        //Arrange
        var escapeGame = CreateValidEscapeGame();
        
        //Act
        var result = EscapeGame.SolveRiddle(escapeGame, "123", 999);
        
        //Assert
        result.Errors.Should().BeEquivalentTo(new List<Error> { new RiddleNotFoundError() });
        result.IsSuccess.Should().BeFalse();
    }
    
    [Fact]
    public void SolveRiddle_WrongValue_ReturnsRiddleSolutionNotCorrectError()
    {
        //Arrange
        var escapeGame = CreateValidEscapeGame();
        
        //Act
        var result = EscapeGame.SolveRiddle(escapeGame, "124", 0);
        
        //Assert
        result.Errors.Should().BeEquivalentTo(new List<Error> { new RiddleSolutionIsNotCorrectError() });
        result.IsSuccess.Should().BeFalse();
    }
    
    [Fact]
    public void SolveRiddle_CorrectValue_ReturnsUpdatedEscapeGame()
    {
        //Arrange
        var escapeGame = CreateValidEscapeGame();
        
        //Act
        var result = EscapeGame.SolveRiddle(escapeGame, "123", 0);
        
        //Assert
        result.Errors.Should().BeEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Value.Should().BeEquivalentTo(escapeGame, options => options.Excluding(x => x.Riddles));
        result.Value.Riddles.ElementAt(0).IsSolved.Value.Should().BeTrue();
    }


    private EscapeGame CreateValidEscapeGame()
    {
        const string culture = "de-DE";
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create().Value;
        var riddle = Riddle.Create(riddleSolution, isSolved).Value;
        var gameSolution = GameSolution.Create("SolutionPhrase 123").Value;
        var groupNumber = GroupNumber.Create(2).Value;
        var gameSolutionForGroup = GameSolutionForGroup.Create(groupNumber, gameSolution).Value;
        return EscapeGame.Create(culture, new[] { riddle }, new []{ gameSolutionForGroup }, _defaultCreatorPassword).Value;

    }
}