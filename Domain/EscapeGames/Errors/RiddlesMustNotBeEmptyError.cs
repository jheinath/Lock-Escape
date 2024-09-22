using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddlesMustNotBeEmptyError() : Error(_Errors.RiddlesMustNotBeEmptyErrorMessage);