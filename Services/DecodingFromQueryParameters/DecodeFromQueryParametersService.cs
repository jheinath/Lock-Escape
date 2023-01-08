using System.Globalization;
using System.Text;
using System.Web;
using Domain.EscapeGames.ValueObjects;
using HashidsNet;
using LockEscape.Helpers;

namespace LockEscape.Services.DecodingFromQueryParameters;

public class DecodeFromQueryParametersService : IDecodeFromQueryParametersService
{
    public EscapeGameDto DecodeToEscapeGameDto(string src)
    {
        var hashids = new Hashids(HashIdConfiguration.Salt);
        var decodedHex= hashids.DecodeHex(src);
        var byteArray = FromHex(decodedHex);
        var queryString = Encoding.ASCII.GetString(byteArray);

        var creatorPassword = HttpUtility.ParseQueryString(queryString).Get(nameof(CreatorPassword));
        var cultureInfo = HttpUtility.ParseQueryString(queryString).Get(nameof(CultureInfo));

        var dic = queryString.DecodeQueryParameters();

        return new EscapeGameDto
        {
            CreatorPassword = dic.GetValueOrDefault(nameof(CreatorPassword)),
            CultureInfo = dic.GetValueOrDefault(nameof(CultureInfo)),
            RiddleSolutionDtos = CreateRiddleSolutionDtos(dic),
            GameSolutionForGroupDtos = CreateSolutionForGroupDtos(dic)
        };
    }

    private static IEnumerable<GameSolutionForGroupDto> CreateSolutionForGroupDtos(Dictionary<string, string?> dic)
    {
        var solutions = dic.Where(x => x.Key.StartsWith(nameof(GameSolution))).OrderBy(x => x.Key);
        var groupNumber = dic.Where(x => x.Key.StartsWith(nameof(GroupNumber))).OrderBy(x => x.Key);

        return solutions.Select(x => new GameSolutionForGroupDto
        {
            GameSolution = x.Value,
            GroupNumber = int.Parse(groupNumber.ElementAt(x.Key[^1]).Value ?? string.Empty)
        });
    }

    private static IEnumerable<RiddleSolutionDto> CreateRiddleSolutionDtos(Dictionary<string, string?> dic)
    {
        var solutions = dic.Where(x => x.Key.StartsWith(nameof(RiddleSolution))).OrderBy(x => x.Key);
        var isSolvedValues = dic.Where(x => x.Key.StartsWith(nameof(IsSolved))).OrderBy(x => x.Key);

        return solutions.Select(x => new RiddleSolutionDto()
        {
            RiddleSolution = x.Value,
            IsSolved = bool.Parse(isSolvedValues.ElementAt(x.Key[^1]).Value ?? string.Empty)
        });
    }

    private static byte[] FromHex(string hex)
    {
        hex = hex.Replace("-", "");
        var raw = new byte[hex.Length / 2];
        for (var i = 0; i < raw.Length; i++)
        {
            raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
        }
        return raw;
    }
}