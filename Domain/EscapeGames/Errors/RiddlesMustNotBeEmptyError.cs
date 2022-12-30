using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddlesMustNotBeEmptyError : Error
{
    public RiddlesMustNotBeEmptyError()
        : base(Errors.RiddlesMustNotBeEmptyErrorMessage)
    { }
}