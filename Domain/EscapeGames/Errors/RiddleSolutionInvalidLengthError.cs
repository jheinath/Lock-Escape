using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionInvalidLengthError(params int[] expectedLengths) : Error(
    string.Format(_Errors.RiddleSolutionInvalidLengthErrorMessage, string.Join(", ", expectedLengths)));