using FluentResults;

namespace Domain.EscapeGames.Errors;

public class InvalidCultureError : Error
{
    public InvalidCultureError()
        : base(_Errors.InvalidCultureErrorMessage)
    { }
}