using Application.DataTransferObjects;
using Application.Ports;
using Application.Services;
using Domain.EscapeGames.Aggregate;
using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Application.Commands;

public class SelectGroupCommand : ISelectGroupCommand
{
    private readonly IEscapeGameDtoConversionService _escapeGameDtoConversionService;

    public SelectGroupCommand(IEscapeGameDtoConversionService escapeGameDtoConversionService)
    {
        _escapeGameDtoConversionService = escapeGameDtoConversionService;
    }
    
    public Result<EscapeGame> Execute(int groupNumber, EscapeGameDto escapeGameDto)
    {
        var groupNumberValueObjectResult = GroupNumber.Create(groupNumber);

        if (groupNumberValueObjectResult.IsFailed)
            return Result.Fail(groupNumberValueObjectResult.Errors);

        var escapeGame = _escapeGameDtoConversionService.ConvertToDomainObject(escapeGameDto);
        
        return EscapeGame.SelectGroupNumber(escapeGame, groupNumberValueObjectResult.Value);
    }
}