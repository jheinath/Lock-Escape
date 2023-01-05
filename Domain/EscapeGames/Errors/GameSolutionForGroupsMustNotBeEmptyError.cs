using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GameSolutionForGroupsMustNotBeEmptyError : Error
{
    public GameSolutionForGroupsMustNotBeEmptyError()
        : base(_Errors.GameSolutionForGroupsMustNotBeEmptyErrorMessage)
    { }
}