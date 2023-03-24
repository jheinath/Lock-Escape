using Application.DataTransferObjects;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Ports;

public interface IResetGameCommand
{
    public Result<EscapeGame> Execute(EscapeGameDto escapeGameDto);
}