using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionInvalidFormatError : Error
{
    public RiddleSolutionInvalidFormatError()
        : base(Errors.RiddleSolutionInvalidFormatErrorMessage)
    { }
}