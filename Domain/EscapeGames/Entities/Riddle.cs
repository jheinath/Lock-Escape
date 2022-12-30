using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Domain.EscapeGames.Entities;

public class Riddle
{
    public RiddleSolution RiddleSolution { get; }
    public IsSolved IsSolved { get; }
    
    private Riddle(RiddleSolution riddleSolution, IsSolved isIsSolved)
    {
        RiddleSolution = riddleSolution;
        IsSolved = isIsSolved;
    }

    public static Result<Riddle> Create(RiddleSolution riddleSolution, IsSolved isSolved)
    {
        return new Result<Riddle>().WithValue(new Riddle(riddleSolution, isSolved));
    }
}