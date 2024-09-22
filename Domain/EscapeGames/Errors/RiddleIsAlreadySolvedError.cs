using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleIsAlreadySolvedError() : Error(_Errors.RiddleIsAlreadySolvedErrorMessage);