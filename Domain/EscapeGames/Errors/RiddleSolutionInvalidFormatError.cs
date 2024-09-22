using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionInvalidFormatError() : Error(_Errors.RiddleSolutionInvalidFormatErrorMessage);