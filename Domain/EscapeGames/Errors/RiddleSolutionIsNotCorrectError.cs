using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionIsNotCorrectError() : Error(_Errors.RiddleSolutionIsNotCorrectErrorMessage);