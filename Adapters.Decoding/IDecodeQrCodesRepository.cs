namespace Adapters.Decoding;

public interface IDecodeQrCodesRepository
{
    public string DecodeQrCodeToUrl(byte[] dataArray, int imageHeight, int imageWidth);
}