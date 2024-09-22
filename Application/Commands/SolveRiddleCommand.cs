using Application.DataTransferObjects;
using Application.Ports;
using Application.Services;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Commands;

public class SolveRiddleCommand(IEscapeGameDtoConversionService escapeGameDtoConversionService)
    : ISolveRiddleCommand
{
    public Result<EscapeGame> Execute(string valueToSolveRiddle, EscapeGameDto escapeGameDto, int riddleNumber)
    {
        var escapeGame = escapeGameDtoConversionService.ConvertToDomainObject(escapeGameDto);
        
        return EscapeGame.SolveRiddle(escapeGame, valueToSolveRiddle, riddleNumber);
    }
}