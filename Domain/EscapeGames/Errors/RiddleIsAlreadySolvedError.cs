using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleIsAlreadySolvedError : Error
{
    public RiddleIsAlreadySolvedError()
        : base(_Errors.RiddleIsAlreadySolvedErrorMessage)
    { }
}