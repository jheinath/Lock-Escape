using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionInvalidLengthError : Error
{
    public RiddleSolutionInvalidLengthError(int expectedLength)
        : base(string.Format(Errors.RiddleSolutionInvalidLengthErrorMessage, expectedLength))
    { }
}