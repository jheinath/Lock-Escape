using Domain.EscapeGames.Errors;
using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class CreatorPassword
{
    public string Value { get; }
    
    private CreatorPassword(string value)
    {
        Value = value;
    }
    
    public static Result<CreatorPassword> Create(string? value)
    {
        var result = new Result<CreatorPassword>();
        if (string.IsNullOrWhiteSpace(value))
            result.WithError(new CreatorPasswordMustNotBeEmptyError());

        if (result.IsFailed)
            return result;

        result.WithValue(new CreatorPassword(value!));
        
        return result;
    }
}