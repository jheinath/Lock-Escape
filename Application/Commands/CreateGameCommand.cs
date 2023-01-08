using Application.Enums;
using Application.Ports;
using Domain.EscapeGames.Aggregate;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Application.Commands;

public class CreateGameCommand : ICreateGameCommand
{
    public Result<EscapeGame> Execute(Language language, IEnumerable<string?> riddleSolutions,
        IEnumerable<string?> gameSolutions, string? creatorPassword)
    {
        var riddlesResult = CreateRiddles(riddleSolutions);
        var gameSolutionsResult = CreateGameSolutionForGroups(gameSolutions);
        var creatorPasswordResult = CreateCreatorPassword(creatorPassword);
        var mergedResult = Result.Merge(riddlesResult, creatorPasswordResult, gameSolutionsResult);

        if (mergedResult.IsFailed) return mergedResult;

        return EscapeGame.Create(MapCulture(language), riddlesResult.Value, gameSolutionsResult.Value,
            creatorPasswordResult.Value);
    }

    private static Result<IEnumerable<GameSolutionForGroup>> CreateGameSolutionForGroups(
        IEnumerable<string?> gameSolutions)
    {
        var i = 1;
        var results = gameSolutions.Select(x => CreateGameSolution(x, i++)).ToList();

        return results.Merge();
    }

    private static Result<CreatorPassword> CreateCreatorPassword(string? creatorPassword)
    {
        return CreatorPassword.Create(creatorPassword);
    }

    private static Result<GameSolutionForGroup> CreateGameSolution(string? gameSolution, int groupNumber)
    {
        var gameSolutionResult = GameSolution.Create(gameSolution);
        if (gameSolutionResult.IsFailed)
            return new Result<GameSolutionForGroup>().WithErrors(gameSolutionResult.Errors);

        var groupNumberResult = GroupNumber.Create(groupNumber);
        if (groupNumberResult.IsFailed)
            return new Result<GameSolutionForGroup>().WithErrors(groupNumberResult.Errors);

        return GameSolutionForGroup.Create(groupNumberResult.Value, gameSolutionResult.Value);
    }

    private static Result<IEnumerable<Riddle>> CreateRiddles(IEnumerable<string?> riddleSolutions)
    {
        var results = riddleSolutions.Select(CreateRiddle).ToList();

        return results.Merge();
    }

    private static Result<Riddle> CreateRiddle(string? riddleSolution)
    {
        var riddleSolutionResult = RiddleSolution.Create(riddleSolution);
        if (riddleSolutionResult.IsFailed) return new Result<Riddle>().WithErrors(riddleSolutionResult.Errors);

        var isSolvedResult = IsSolved.Create();
        if (isSolvedResult.IsFailed) return new Result<Riddle>().WithErrors(isSolvedResult.Errors);

        return Riddle.Create(riddleSolutionResult.Value, isSolvedResult.Value);
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