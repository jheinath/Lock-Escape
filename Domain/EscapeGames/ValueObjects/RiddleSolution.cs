using Domain.EscapeGames.Errors;
using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class RiddleSolution
{
    public string Value { get; }
    
    private RiddleSolution(string value)
    {
        Value = value;
    }

    public static IEnumerable<int> AllowedSolutionLengths => new[] { 3, 4 }; 

    public static Result<RiddleSolution> Create(string? riddleSolution)
    {
        var result = new Result<RiddleSolution>();
        
        if (string.IsNullOrWhiteSpace(riddleSolution))
            result.WithError(new RiddleSolutionMustNotBeEmptyError());

        if (!IsDigitsOnly(riddleSolution))
            result.WithError(new RiddleSolutionInvalidFormatError());

        var length = riddleSolution?.Trim().Length ?? 0;
        if (!AllowedSolutionLengths.Contains(length))
            result.WithError(new RiddleSolutionInvalidLengthError(AllowedSolutionLengths.ToArray()));

        if (result.IsFailed)
            return result;

        result.WithValue(new RiddleSolution(riddleSolution!));
        
        return result;
    }
    
    private static bool IsDigitsOnly(string? str) => str is not null && str.All(char.IsDigit);
}