using Application.Enums;
using FluentResults;

namespace Application.Commands;

public class CreateGameCommand
{
    public CreateGameCommand()
    {
        
    }

    public Result Execute(Language language, IEnumerable<string> riddleSolutions)
    {
        var result = new Result();
        return result;
    }
}