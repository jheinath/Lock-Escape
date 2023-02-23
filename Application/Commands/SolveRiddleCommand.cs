using Application.DataTransferObjects;
using Application.Ports;
using Application.Services;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Commands;

public class SolveRiddleCommand : ISolveRiddleCommand
{
    private readonly IEscapeGameDtoConversionService _escapeGameDtoConversionService;

    public SolveRiddleCommand(IEscapeGameDtoConversionService escapeGameDtoConversionService)
    {
        _escapeGameDtoConversionService = escapeGameDtoConversionService;
    }
    
    public Result<EscapeGame> Execute(string valueToSolveRiddle, EscapeGameDto escapeGameDto, int riddleNumber)
    {
        var escapeGame = _escapeGameDtoConversionService.ConvertToDomainObject(escapeGameDto);
        
        return EscapeGame.SolveRiddle(escapeGame, valueToSolveRiddle, riddleNumber);
    }
}