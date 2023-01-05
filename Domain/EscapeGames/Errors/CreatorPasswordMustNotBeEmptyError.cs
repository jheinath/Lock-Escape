using FluentResults;

namespace Domain.EscapeGames.Errors;

public class CreatorPasswordMustNotBeEmptyError : Error
{
    public CreatorPasswordMustNotBeEmptyError()
        : base(_Errors.CreatorPasswordMustNotBeEmptyErrorMessage)
    { }
}