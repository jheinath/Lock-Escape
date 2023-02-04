using FluentResults;

namespace Domain.EscapeGames.Errors;

public class SelectGroupNumberIsNotAvailableError : Error
{
    public SelectGroupNumberIsNotAvailableError()
        : base(_Errors.SelectGroupNumberIsNotAvailableErrorMessage)
    { }
}