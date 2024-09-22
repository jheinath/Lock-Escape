using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GameSolutionMustNotBeEmptyError() : Error(_Errors.GameSolutionMustNotBeEmptyErrorMessage);