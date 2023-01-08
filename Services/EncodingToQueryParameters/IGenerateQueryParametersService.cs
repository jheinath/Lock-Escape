using Domain.EscapeGames.Aggregate;

namespace LockEscape.Services.EncodingToQueryParameters;

public interface IGenerateQueryParametersService
{
    public string GenerateQueryParameters(EscapeGame escapeGame);
}