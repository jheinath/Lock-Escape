using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class IsSolved
{
    public bool Value { get; }

    private IsSolved(bool value)
    {
        Value = value;
    }
    
    public static Result<IsSolved> Create()
    {
        var @object = new IsSolved(false);
        return new Result<IsSolved>().WithValue(@object);
    }
    
    public static Result<IsSolved> Create(bool value)
    {
        var @object = new IsSolved(value);
        return new Result<IsSolved>().WithValue(@object);
    }
}