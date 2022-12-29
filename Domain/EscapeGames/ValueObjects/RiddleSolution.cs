using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class RiddleSolution
{
    public string Value { get; private set; }
    
    private RiddleSolution(string value)
    {
        Value = value;
    }
    
    public static Result<RiddleSolution> Create(string riddleSolution)
    {
        var result = new Result<RiddleSolution>();
        if (string.IsNullOrWhiteSpace(riddleSolution))
            result.WithError(new Error("Riddle solutions must not be empty."));

        if (IsDigitsOnly(riddleSolution))
            result.WithError(new Error("Riddle solutions must only contain digits (0-9)."));

        if (riddleSolution.Trim().Length != 3)
            result.WithError(new Error("Riddle solution must have 3 digits"));

        if (result.IsFailed)
            return result;

        result.WithValue(new RiddleSolution(riddleSolution));
        
        return result;
    }
    
    private static bool IsDigitsOnly(string str)
    {
        return str.All(c => c is >= '0' and <= '9');
    }
}