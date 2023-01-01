namespace Adapters.Decoding;

public class DecodeQrCodesRepository : IDecodeQrCodesRepository
{
    public string DecodeQrCodeToUrl(byte[] dataArray, int imageHeight, int imageWidth)
    {
        // IBarcodeReader reader = new BarcodeReader();
        // var src = new RGBLuminanceSource()
        // reader.Decode()
        // var result = reader.Decode(dataArray, imageWidth, imageHeight, RGBLuminanceSource.BitmapFormat.RGB32);
        // Console.WriteLine(result.Text);
        return String.Empty;
    }
}