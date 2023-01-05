using Domain.EscapeGames.Errors;
using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class GameSolution
{
    public string Value { get; }
    
    private GameSolution(string value)
    {
        Value = value;
    }
    
    public static Result<GameSolution> Create(string? gameSolution)
    {
        var result = new Result<GameSolution>();
        if (string.IsNullOrWhiteSpace(gameSolution))
            result.WithError(new GameSolutionMustNotBeEmptyError());

        if (result.IsFailed)
            return result;

        result.WithValue(new GameSolution(gameSolution!));
        
        return result;
    }
}