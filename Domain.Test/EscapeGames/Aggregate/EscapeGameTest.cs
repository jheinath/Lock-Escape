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
    [Fact]
    public void Create_InvalidCultureInput_ReturnInvalidCultureError()
    {
        //Arrange
        var expectedError = new InvalidCultureError();
        
        //Act
        var result = EscapeGame.Create(null, new List<Riddle>());
        
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
        var result = EscapeGame.Create("de-DE", new List<Riddle>());
        
        //Assert
        result.IsFailed.Should().BeTrue();
        result.Errors.Should().BeEquivalentTo(new List<Error>() { expectedError });
    }

    [Fact]
    public void Create_ValidInput_CreatesEscapeGameCorrectly()
    {
        //Arrange
        const string culture = "de-DE";
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create().Value;
        var riddle = Riddle.Create(riddleSolution, isSolved).Value;
        
        //Act
        var result = EscapeGame.Create(culture, new[] { riddle });
        
        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Errors.Should().BeEmpty();
        result.Value.CultureInfo.Should().BeEquivalentTo(new CultureInfo(culture));
        result.Value.Riddles.Should().BeEquivalentTo(new[] { riddle });
    }
}