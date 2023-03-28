using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Domain.EscapeGames.Entities;

public class GameSolutionForGroup
{
    public GameSolution GameSolution { get; }
    public GroupNumber? GroupNumber { get; }

    private GameSolutionForGroup(GroupNumber? groupNumber, GameSolution gameSolution)
    {
        GroupNumber = groupNumber;
        GameSolution = gameSolution;
    }
    
    public static Result<GameSolutionForGroup> Create(GroupNumber? groupNumber, GameSolution gameSolution)
    {
        return new Result<GameSolutionForGroup>().WithValue(new GameSolutionForGroup(groupNumber, gameSolution));
    }
}