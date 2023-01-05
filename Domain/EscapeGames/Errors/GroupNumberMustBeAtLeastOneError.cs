using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GroupNumberMustBeAtLeastOneError : Error
{
    public GroupNumberMustBeAtLeastOneError()
        : base(_Errors.GroupNumberMustBeAtLeastOneErrorMessage)
    { }
}