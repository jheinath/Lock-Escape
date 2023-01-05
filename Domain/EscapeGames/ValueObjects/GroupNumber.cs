using Domain.EscapeGames.Errors;
using FluentResults;

namespace Domain.EscapeGames.ValueObjects;

public class GroupNumber
{
    public int Value { get; }

    private GroupNumber(int value)
    {
        Value = value;
    }
    
    public static Result<GroupNumber> Create(int value)
    {
        var result = new Result<GroupNumber>();

        if (value < 1)
            result.WithError(new GroupNumberMustBeAtLeastOneError());

        if (result.IsFailed)
            return result;
        
        var @object = new GroupNumber(value);
        
        return new Result<GroupNumber>().WithValue(@object);
    }
}