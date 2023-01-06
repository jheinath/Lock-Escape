using Application.Enums;
using Domain.EscapeGames.Entities;
using FluentResults;

namespace Application.Ports;

public interface ICreateGameCommand
{
    public Result<GameSolutionForGroup> Execute(Language language, IEnumerable<string> riddleSolutions, IEnumerable<string> gameSolutions);
}