using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GameSolutionForGroupsMustNotBeEmptyError() : Error(_Errors.GameSolutionForGroupsMustNotBeEmptyErrorMessage);