using Domain.EscapeGames.Entities;
using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using Domain.Test.Lib;
using FluentAssertions;
using FluentResults;
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
        result.Should().BeSuccessfulWithoutErrors();
        result.Value.IsSolved.Should().BeEquivalentTo(isSolved);
        result.Value.RiddleSolution.Should().BeEquivalentTo(riddleSolution);
    }

    [Fact]
    public void Solve_AlreadySolved_ReturnsAlreadySolvedError()
    {
        //Arrange
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create(true).Value;
        var riddle = Riddle.Create(riddleSolution, isSolved).Value;
        
        //Act
        var result = Riddle.Solve(riddle, "123");
        
        //Assert
        result.Errors.Should().BeSingleErrorListWith(new RiddleIsAlreadySolvedError());
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void Solve_WrongValue_ReturnsRiddleSolutionNotCorrectError()
    {
        //Arrange
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create().Value;
        var riddle = Riddle.Create(riddleSolution, isSolved).Value;
        
        //Act
        var result = Riddle.Solve(riddle, "124");
        
        //Assert
        result.Errors.Should().BeSingleErrorListWith(new RiddleSolutionIsNotCorrectError());
        result.IsFailed.Should().BeTrue();
    }
    
    [Fact]
    public void Solve_CorrectValue_ReturnsSolvedRiddle()
    {
        //Arrange
        var riddleSolution = RiddleSolution.Create("123").Value;
        var isSolved = IsSolved.Create().Value;
        var riddle = Riddle.Create(riddleSolution, isSolved).Value;
        
        //Act
        var result = Riddle.Solve(riddle, "123");
        
        //Assert
        result.Should().BeSuccessfulWithoutErrors();
        result.Value.IsSolved.Value.Should().BeTrue();
    }
}