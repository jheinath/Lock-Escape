using Application.Enums;
using FluentResults;

namespace Application.Ports;

public interface ICreateGameCommand
{
    public Result Execute(Language language, IEnumerable<string> riddleSolutions, IEnumerable<string> gameSolutions);
}