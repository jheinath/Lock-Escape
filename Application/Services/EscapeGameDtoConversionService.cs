using System.Globalization;
using Application.DataTransferObjects;
using Domain.EscapeGames.Aggregate;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.ValueObjects;

namespace Application.Services;

public class EscapeGameDtoConversionService : IEscapeGameDtoConversionService
{
    public EscapeGame ConvertToDomainObject(EscapeGameDto escapeGameDto)
    {
        var cultureInfo = new CultureInfo(escapeGameDto.CultureInfo!);
        var riddles = escapeGameDto.RiddleSolutionDtos.Select(x => Riddle.Create(RiddleSolution.Create(x.RiddleSolution).Value, 
            IsSolved.Create(x.IsSolved).Value).Value);
        var gameSolutionsForGroups = escapeGameDto.GameSolutionForGroupDtos.Select(x =>
            GameSolutionForGroup.Create(GroupNumber.Create(x.GroupNumber).Value, GameSolution.Create(x.GameSolution).Value).Value);
        var groupNumber = escapeGameDto.SelectedGroupNumber is null ? null : GroupNumber.Create(int.Parse(escapeGameDto.SelectedGroupNumber)).Value;
        
        return EscapeGame.Load(cultureInfo, riddles.ToList(), gameSolutionsForGroups,
            CreatorPassword.Create(escapeGameDto.CreatorPassword).Value, groupNumber!);
    }
}