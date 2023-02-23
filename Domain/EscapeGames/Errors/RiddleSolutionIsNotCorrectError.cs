using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionIsNotCorrectError : Error
{
    public RiddleSolutionIsNotCorrectError()
        : base(_Errors.RiddleSolutionIsNotCorrectErrorMessage)
    { }
}