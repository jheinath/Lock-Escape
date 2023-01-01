using Adapters.Decoding;

namespace Application.Queries;

public class GetUrlByQrCodeImageAsync
{
    private readonly IDecodeQrCodesRepository _decodeQrCodesRepository;

    public GetUrlByQrCodeImageAsync(IDecodeQrCodesRepository decodeQrCodesRepository)
    {
        _decodeQrCodesRepository = decodeQrCodesRepository;
    }

    public string Execute(byte[] qrCodeImage, int imageHeight, int imageWidth)
    {
        return _decodeQrCodesRepository.DecodeQrCodeToUrl(qrCodeImage, imageHeight, imageWidth);
    }
}