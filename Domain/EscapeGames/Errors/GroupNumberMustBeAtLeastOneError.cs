using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GroupNumberMustBeAtLeastOneError : Error
{
    public GroupNumberMustBeAtLeastOneError()
        : base(Errors.GroupNumberMustBeAtLeastOneErrorMessage)
    { }
}