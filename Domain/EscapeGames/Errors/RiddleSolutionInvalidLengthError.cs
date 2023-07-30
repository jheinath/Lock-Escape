using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionInvalidLengthError : Error
{
    public RiddleSolutionInvalidLengthError(params int[] expectedLengths)
        : base(string.Format(_Errors.RiddleSolutionInvalidLengthErrorMessage, string.Join(", ", expectedLengths)))
    { }
}