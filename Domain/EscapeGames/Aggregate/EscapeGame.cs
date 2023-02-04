using System.Globalization;
using Domain.EscapeGames.Entities;
using Domain.EscapeGames.Errors;
using Domain.EscapeGames.ValueObjects;
using FluentResults;

namespace Domain.EscapeGames.Aggregate;

public class EscapeGame
{
    public CultureInfo CultureInfo { get; private set; }
    public IEnumerable<Riddle> Riddles { get; private set; }
    public IEnumerable<GameSolutionForGroup> GameSolutionForGroups { get; }
    public CreatorPassword CreatorPassword { get; }
    public GroupNumber SelectedGroupNumber { get; }

    private EscapeGame(CultureInfo cultureInfo, IEnumerable<Riddle> riddles,
        IEnumerable<GameSolutionForGroup> gameSolutionForGroups, CreatorPassword creatorPassword, GroupNumber selectedGroupNumber)
    {
        CultureInfo = cultureInfo;
        Riddles = riddles;
        GameSolutionForGroups = gameSolutionForGroups;
        CreatorPassword = creatorPassword;
        SelectedGroupNumber = selectedGroupNumber;
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
}