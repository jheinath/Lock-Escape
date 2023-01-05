using System.Globalization;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.Errors;
using FluentResults;

namespace Domain.EscapeGames.Aggregate;

public class EscapeGame
{
    public CultureInfo CultureInfo { get; private set; }
    public IEnumerable<Riddle> Riddles { get; private set; }
    public IEnumerable<GameSolutionForGroup> GameSolutionForGroups { get; }

    private EscapeGame(CultureInfo cultureInfo, IEnumerable<Riddle> riddles, IEnumerable<GameSolutionForGroup> gameSolutionForGroups)
    {
        CultureInfo = cultureInfo;
        Riddles = riddles;
        GameSolutionForGroups = gameSolutionForGroups;
    }

    public static Result<EscapeGame> Create(string cultureInfo, IEnumerable<Riddle> riddles, IEnumerable<GameSolutionForGroup> gameSolutionForGroups)
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

        return result.WithValue(new EscapeGame(new CultureInfo(cultureInfo), riddles, gameSolutionForGroups));
    }
}