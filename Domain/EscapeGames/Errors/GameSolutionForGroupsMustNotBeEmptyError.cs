using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GameSolutionForGroupsMustNotBeEmptyError : Error
{
    public GameSolutionForGroupsMustNotBeEmptyError()
        : base(Errors.GameSolutionForGroupsMustNotBeEmptyErrorMessage)
    { }
}