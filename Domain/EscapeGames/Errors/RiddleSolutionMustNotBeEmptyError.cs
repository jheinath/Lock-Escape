﻿using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddleSolutionMustNotBeEmptyError : Error
{
    public RiddleSolutionMustNotBeEmptyError()
        : base(_Errors.RiddleSolutionMustNotBeEmptyErrorMessage)
    { }
}