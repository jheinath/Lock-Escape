using System.Globalization;
using System.Text;
using Application.DataTransferObjects;
using Domain.EscapeGames.Aggregate;
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

        var dic = queryString.DecodeQueryParameters();

        return new EscapeGameDto
        {
            SelectedGroupNumber = dic.GetValueOrDefault(nameof(EscapeGame.SelectedGroupNumber)),
            CreatorPassword = dic.GetValueOrDefault(nameof(CreatorPassword)),
            CultureInfo = dic.GetValueOrDefault(nameof(CultureInfo)),
            RiddleSolutionDtos = CreateRiddleSolutionDtos(dic!),
            GameSolutionForGroupDtos = CreateSolutionForGroupDtos(dic!)
        };
    }

    private static IEnumerable<GameSolutionForGroupDto> CreateSolutionForGroupDtos(Dictionary<string, string?> dic)
    {
        var solutions = dic.Where(x => x.Key.StartsWith(nameof(GameSolution))).OrderBy(x => x.Key).ToList();
        var groupNumbers = dic.Where(x => x.Key.StartsWith(nameof(GroupNumber))).OrderBy(x => x.Key).ToList();

        var dtos = new List<GameSolutionForGroupDto>();
        for (var i = 0; i < solutions.Count; i++)
        {
            dtos.Add(new GameSolutionForGroupDto
            {
                GameSolution = solutions.ElementAtOrDefault(i).Value,
                GroupNumber = int.Parse(groupNumbers.ElementAtOrDefault(i).Value ?? "1")
            });
        }

        return dtos;
    }

    private static IEnumerable<RiddleSolutionDto> CreateRiddleSolutionDtos(Dictionary<string, string?> dic)
    {
        var solutions = dic.Where(x => x.Key.StartsWith(nameof(RiddleSolution))).OrderBy(x => x.Key).ToList();
        var isSolvedValues = dic.Where(x => x.Key.StartsWith(nameof(IsSolved))).OrderBy(x => x.Key).ToList();
        var dtos = new List<RiddleSolutionDto>();
        
        for (var i = 0; i < solutions.Count; i++)
        {
            dtos.Add(new RiddleSolutionDto()
            {
                RiddleSolution = solutions.ElementAt(i).Value,
                IsSolved = bool.Parse(isSolvedValues.ElementAt(i).Value ?? bool.FalseString)
            });
        }

        return dtos;
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