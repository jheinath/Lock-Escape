using System.Globalization;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using Domain.Extensions;
using FluentResults;

namespace Domain.EscapeGames.Aggregate;

public class EscapeGame
{
    public CultureInfo CultureInfo { get; private init; }
    public IEnumerable<Riddle> Riddles { get; private set; }
    public IEnumerable<GameSolutionForGroup> GameSolutionForGroups { get; private init; }
    public CreatorPassword CreatorPassword { get; private init; }
    public GroupNumber SelectedGroupNumber { get; private set; }

    private EscapeGame(CultureInfo cultureInfo, IEnumerable<Riddle> riddles,
        IEnumerable<GameSolutionForGroup> gameSolutionForGroups, CreatorPassword creatorPassword, GroupNumber selectedGroupNumber)
    {
        CultureInfo = cultureInfo;
        Riddles = riddles;
        GameSolutionForGroups = gameSolutionForGroups;
        CreatorPassword = creatorPassword;
        SelectedGroupNumber = selectedGroupNumber;
    }


    public static EscapeGame Load(CultureInfo cultureInfo, IEnumerable<Riddle> riddles,
        IEnumerable<GameSolutionForGroup> gameSolutionForGroups, CreatorPassword creatorPassword,
        GroupNumber selectedGroupNumber)
    {
        return new EscapeGame(cultureInfo, riddles, gameSolutionForGroups, creatorPassword, selectedGroupNumber);
    }
    
    public static Result<EscapeGame> Create(string cultureInfo, IEnumerable<Riddle> riddles,
        IEnumerable<GameSolutionForGroup> gameSolutionForGroups, CreatorPassword creatorPassword)
    {
        var result = new Result<EscapeGame>();

        try
        {
            var unused = new CultureInfo(cultureInfo);
        }
        catch (Exception e)
        {
            if (e is ArgumentNullException or CultureNotFoundException)
                result.WithError(new InvalidCultureError());

            return result;
        }

        if (!riddles.Any())
            result.WithError(new RiddlesMustNotBeEmptyError());

        if (!gameSolutionForGroups.Any())
            result.WithError(new GameSolutionForGroupsMustNotBeEmptyError());

        if (result.IsFailed)
            return result;

        return result.WithValue(new EscapeGame(new CultureInfo(cultureInfo), riddles, gameSolutionForGroups, creatorPassword, null));
    }

    public static Result<EscapeGame> SelectGroupNumber(EscapeGame escapeGame, GroupNumber groupNumber)
    {
        var result = new Result<EscapeGame>();

        if (escapeGame.GameSolutionForGroups.All(gameSolution => gameSolution.GroupNumber.Value != groupNumber.Value))
            result.WithError(new SelectGroupNumberIsNotAvailableError());

        if (result.IsFailed)
            return result;

        escapeGame.SelectedGroupNumber = groupNumber;

        return result.WithValue(escapeGame);
    }

    public static Result<EscapeGame> SolveRiddle(EscapeGame escapeGame, string valueToSolveRiddle, int riddleNumber)
    {
        var result = new Result<EscapeGame>();

        var riddleToSolve = escapeGame.Riddles.ElementAtOrDefault(riddleNumber);

        if (riddleToSolve is null)
        {
            result.WithError(new RiddleNotFoundError());
            return result;
        }

        var riddleResult = Riddle.Solved(riddleToSolve, valueToSolveRiddle);
        
        
        if (riddleResult.IsFailed)
            return Result.Fail(riddleResult.Errors);

        escapeGame.Riddles.ToList().Replace(riddleNumber, riddleResult.Value);

        return result.WithValue(escapeGame);
    }
}