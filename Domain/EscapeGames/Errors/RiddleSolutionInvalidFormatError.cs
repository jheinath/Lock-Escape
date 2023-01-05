using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionInvalidFormatError : Error
{
    public RiddleSolutionInvalidFormatError()
        : base(_Errors.RiddleSolutionInvalidFormatErrorMessage)
    { }
}