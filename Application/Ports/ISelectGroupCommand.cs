using Application.DataTransferObjects;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Ports;

public interface ISelectGroupCommand
{
    public Result<EscapeGame> Execute(int groupNumber, EscapeGameDto escapeGameDto);
}