using Application.DataTransferObjects;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Ports;

public interface ISolveRiddleCommand
{
    public Result<EscapeGame> Execute(string valueToSolveRiddle, EscapeGameDto escapeGameDto, int riddleNumber);
}