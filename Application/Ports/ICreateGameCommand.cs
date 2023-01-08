using Application.Enums;
using Domain.EscapeGames.Aggregate;
using FluentResults;

namespace Application.Ports;

public interface ICreateGameCommand
{
    public Result<EscapeGame> Execute(Language language, IEnumerable<string?> riddleSolutions,
        IEnumerable<string?> gameSolutions, string? creatorPassword);
}