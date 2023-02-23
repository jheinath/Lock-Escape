using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleNotFoundError : Error
{
    public RiddleNotFoundError()
        : base(_Errors.RiddleNotFoundErrorMessage)
    { }
}