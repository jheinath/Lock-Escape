using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GameSolutionMustNotBeEmptyError : Error
{
    public GameSolutionMustNotBeEmptyError()
        : base(Errors.GameSolutionMustNotBeEmptyErrorMessage)
    { }
}