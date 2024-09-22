using Application.DataTransferObjects;
using Application.Ports;
using Application.Services;
using Domain.EscapeGames.Aggregate;
using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Application.Commands;

public class SelectGroupCommand(IEscapeGameDtoConversionService escapeGameDtoConversionService)
    : ISelectGroupCommand
{
    public Result<EscapeGame> Execute(int groupNumber, EscapeGameDto escapeGameDto)
    {
        var groupNumberValueObjectResult = GroupNumber.Create(groupNumber);

        if (groupNumberValueObjectResult.IsFailed)
            return Result.Fail(groupNumberValueObjectResult.Errors);

        var escapeGame = escapeGameDtoConversionService.ConvertToDomainObject(escapeGameDto);
        
        return EscapeGame.SelectGroupNumber(escapeGame, groupNumberValueObjectResult.Value);
    }
}