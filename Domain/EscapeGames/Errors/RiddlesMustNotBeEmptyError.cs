﻿using FluentResults;

namespace Domain.EscapeGames.Errors;

public class RiddlesMustNotBeEmptyError : Error
{
    public RiddlesMustNotBeEmptyError()
        : base(_Errors.RiddlesMustNotBeEmptyErrorMessage)
    { }
}