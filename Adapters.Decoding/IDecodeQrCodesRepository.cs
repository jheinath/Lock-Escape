namespace Application.Ports;

public interface IDecodeQrCodesRepository
{
    public string DecodeQrCodeToUrl(byte[] image);
}