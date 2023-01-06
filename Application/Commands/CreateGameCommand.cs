using Application.Enums;
using Application.Ports;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Application.Commands;

public class CreateGameCommand : ICreateGameCommand
{
    public CreateGameCommand()
    {
    }

    private sealed class CommandContext
    {
        public IEnumerable<Riddle> Riddles { get; set; }
        public IEnumerable<GameSolutionForGroup> GameSolutionForGroups { get; set; }
    }

    public Result Execute(Language language, IEnumerable<string> riddleSolutions, IEnumerable<string> gameSolutions)
    {
        var context = new CommandContext();
        return new Result()
            .OnSuccess(_ => CreateRiddles(riddleSolutions, context))
            .OnSuccess(_ => CreateGameSolutionForGroups(gameSolutions, context))
            .OnSuccess(_ => Result.Ok()));
    }

    private static Result<IEnumerable<GameSolutionForGroup>> CreateGameSolutionForGroups(
        IEnumerable<string> gameSolutions, CommandContext context)
    {
        var i = 1;
        var results = gameSolutions.Select(x => CreateGameSolution(x, i++)).ToList();

        var mergedResult = results.Merge();
        if (mergedResult.IsSuccess)
        {
            context.GameSolutionForGroups = mergedResult.Value;
        }

        return mergedResult;
    }

    private static Result<GameSolutionForGroup> CreateGameSolution(string gameSolution, int groupNumber)
    {
        Result<GameSolution> gameSolutionTemp;
        return new Result<GameSolutionForGroup>()
            .OnSuccess(_ =>
            {
                gameSolutionTemp = GameSolution.Create(gameSolution);
                gameSolutionTemp
                    .OnSuccess(_ => GroupNumber.Create(groupNumber)
                        .OnSuccess(number => GameSolutionForGroup.Create(number, gameSolutionTemp.Value)));
            });
    }

    private static Result<IEnumerable<Riddle>> CreateRiddles(IEnumerable<string> riddleSolutions,
        CommandContext context)
    {
        var results = riddleSolutions.Select(CreateRiddle).ToList();

        var mergedResult = results.Merge();
        if (mergedResult.IsSuccess)
        {
            context.Riddles = mergedResult.Value;
        }

        return mergedResult;
    }

    private static Result<Riddle> CreateRiddle(string riddleSolution)
    {
        Result<RiddleSolution> riddleSolutionTemp;
        return new Result<Riddle>()
            .OnSuccess(_ =>
            {
                riddleSolutionTemp = RiddleSolution.Create(riddleSolution);
                riddleSolutionTemp
                    .OnSuccess(x => IsSolved.Create()
                        .OnSuccess(isSolved => Riddle.Create(riddleSolutionTemp.Value, isSolved)));
            });
    }

    private static string MapCulture(Language language)
    {
        return language switch
        {
            Language.English => "en-GB",
            Language.German => "de-DE",
            _ => "en-GB"
        };
    }
}