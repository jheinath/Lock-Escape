using Application.Ports;

namespace Application.Queries;

public class GetUrlByQrCodeImageAsync
{
    private readonly IDecodeQrCodesRepository _decodeQrCodesRepository;

    public GetUrlByQrCodeImageAsync(IDecodeQrCodesRepository decodeQrCodesRepository)
    {
        _decodeQrCodesRepository = decodeQrCodesRepository;
    }

    public string Execute(byte[] qrCodeImage)
    {
        return _decodeQrCodesRepository.DecodeQrCodeToUrl(qrCodeImage);
    }
}