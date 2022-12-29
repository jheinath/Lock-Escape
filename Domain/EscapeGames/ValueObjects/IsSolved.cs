using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class IsSolved
{
    public bool Value { get; private set; }

    private IsSolved(bool value)
    {
        Value = value;
    }
    
    public static Result<IsSolved> Create()
    {
        var @object = new IsSolved(false);
        return new Result<IsSolved>().WithValue(@object);
    }
}