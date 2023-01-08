namespace LockEscape.Services.DecodingFromQueryParameters;

public interface IDecodeFromQueryParametersService
{
    public EscapeGameDto DecodeToEscapeGameDto(string src);
}