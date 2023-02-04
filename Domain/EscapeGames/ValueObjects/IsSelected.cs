using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class IsSelected
{
    public bool Value { get; }

    private IsSelected(bool value)
    {
        Value = value;
    }
    
    public static Result<IsSelected> Create()
    {
        var @object = new IsSelected(false);
        return new Result<IsSelected>().WithValue(@object);
    }
}