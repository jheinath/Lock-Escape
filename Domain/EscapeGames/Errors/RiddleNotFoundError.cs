using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleNotFoundError() : Error(_Errors.RiddleNotFoundErrorMessage);