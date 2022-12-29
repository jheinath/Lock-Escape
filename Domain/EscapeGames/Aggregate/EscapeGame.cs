using System.Globalization;
using Domain.EscapeGames.Entities;
using FluentResults;

namespace Domain.EscapeGames.Aggregate;

public class EscapeGame
{
    public CultureInfo CultureInfo { get; private set; }
    public IEnumerable<Riddle> Riddles { get; private set; }

    public EscapeGame(CultureInfo cultureInfo, IEnumerable<Riddle> riddles)
    {
        CultureInfo = cultureInfo;
        Riddles = riddles;
    }

    public static Result<EscapeGame> Create(string cultureInfo, IEnumerable<Riddle> riddles)
    {
        var result = new Result<EscapeGame>();

        try
        {
            var unused = new CultureInfo(cultureInfo);
        }
        catch (Exception e)
        {
            if (e is ArgumentNullException or CultureNotFoundException)
                result.WithError(new Error("InvalidCulture"));

            return result;
        }

        if (!riddles.Any())
            result.WithError(new Error("There must be at least one riddle"));

        if (result.IsFailed)
            return result;

        return result.WithValue(new EscapeGame(new CultureInfo(cultureInfo), riddles));
    }
}