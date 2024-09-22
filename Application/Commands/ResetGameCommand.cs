using Application.DataTransferObjects;
using Application.Ports;
using Application.Services;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Commands;

public class ResetGameCommand(IEscapeGameDtoConversionService escapeGameDtoConversionService)
    : IResetGameCommand
{
    public Result<EscapeGame> Execute(EscapeGameDto escapeGameDto)
    {
        var escapeGame = escapeGameDtoConversionService.ConvertToDomainObject(escapeGameDto);
        
        return EscapeGame.RestartGame(escapeGame);
    }
}