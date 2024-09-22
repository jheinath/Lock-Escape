using FluentResults;

namespace Domain.EscapeGames.Errors;

public class CreatorPasswordMustNotBeEmptyError() : Error(_Errors.CreatorPasswordMustNotBeEmptyErrorMessage);