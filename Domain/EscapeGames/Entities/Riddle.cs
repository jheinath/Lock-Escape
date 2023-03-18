using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Domain.EscapeGames.Entities;

public class Riddle
{
    public RiddleSolution RiddleSolution { get; }
    public IsSolved IsSolved { get; private set; }
    
    private Riddle(RiddleSolution riddleSolution, IsSolved isIsSolved)
    {
        RiddleSolution = riddleSolution;
        IsSolved = isIsSolved;
    }

    public static Result<Riddle> Create(RiddleSolution riddleSolution, IsSolved isSolved)
    {
        return new Result<Riddle>().WithValue(new Riddle(riddleSolution, isSolved));
    }

    public static Result<Riddle> Solve(Riddle riddle, string valueToSolveRiddle)
    {
        var result = new Result<Riddle>();

        if (riddle.IsSolved.Value)
            result.WithError(new RiddleIsAlreadySolvedError());

        if (riddle.RiddleSolution.Value != valueToSolveRiddle)
            result.WithError(new RiddleSolutionIsNotCorrectError());

        if (result.IsFailed)
            return result;

        riddle.IsSolved = IsSolved.Create(true).Value;

        return Result.Ok(riddle);
    }
}