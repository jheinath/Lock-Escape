using FluentResults;

namespace Domain.EscapeGames.Errors;

public class InvalidCultureError() : Error(_Errors.InvalidCultureErrorMessage);