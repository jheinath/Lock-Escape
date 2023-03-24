using Application.DataTransferObjects;
using Application.Ports;
using Application.Services;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Commands;

public class ResetGameCommand : IResetGameCommand
{
    private readonly IEscapeGameDtoConversionService _escapeGameDtoConversionService;

    public ResetGameCommand(IEscapeGameDtoConversionService escapeGameDtoConversionService)
    {
        _escapeGameDtoConversionService = escapeGameDtoConversionService;
    }
    
    public Result<EscapeGame> Execute(EscapeGameDto escapeGameDto)
    {
        var escapeGame = _escapeGameDtoConversionService.ConvertToDomainObject(escapeGameDto);
        
        return EscapeGame.RestartGame(escapeGame);
    }
}