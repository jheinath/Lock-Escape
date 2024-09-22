using FluentResults;

namespace Domain.EscapeGames.Errors;

public class GroupNumberMustBeAtLeastOneError() : Error(_Errors.GroupNumberMustBeAtLeastOneErrorMessage);