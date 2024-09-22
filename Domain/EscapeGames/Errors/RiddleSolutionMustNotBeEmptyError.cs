using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionMustNotBeEmptyError() : Error(_Errors.RiddleSolutionMustNotBeEmptyErrorMessage);