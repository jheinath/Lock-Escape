using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Domain.EscapeGames.Entities;

public class GameSolutionForGroup
{
    public GameSolution GameSolution { get; }
    public GroupNumber GroupNumber { get; }
    public IsSelected IsSelected { get; }

    public GameSolutionForGroup(GroupNumber groupNumber, GameSolution gameSolution, IsSelected isSelected)
    {
        GroupNumber = groupNumber;
        GameSolution = gameSolution;
        IsSelected = isSelected;
    }
    
    public static Result<GameSolutionForGroup> Create(GroupNumber groupNumber, GameSolution gameSolution)
    {
        return new Result<GameSolutionForGroup>().WithValue(new GameSolutionForGroup(groupNumber, gameSolution, IsSelected.Create().Value));
    }
}