using Application.DataTransferObjects;
using Domain.EscapeGames.Aggregate;

namespace Application.Services;

public interface IEscapeGameDtoConversionService
{
    public EscapeGame ConvertToDomainObject(EscapeGameDto escapeGameDto);
}