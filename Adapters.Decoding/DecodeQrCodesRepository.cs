using Application.Ports;
using ZXing;

namespace Adapters.Decoding;

public class DecodeQrCodesRepository : IDecodeQrCodesRepository
{
    public string DecodeQrCodeToUrl(byte[] image)
    {
        // create a barcode reader instance
        // IBarcodeReader reader = new BarcodeReader();
        // load a bitmap
        //
        // var barcodeBitmap = (Bitmap)MediaTypeNames.Image.FromFile("C:\\sample-barcode-image.png");
        // // detect and decode the barcode inside the bitmap
        // var result = reader.Decode(Ima);
        // // do something with the result
        // if (result != null)
        // {
        //     txtDecoderType.Text = result.BarcodeFormat.ToString();
        //     txtDecoderContent.Text = result.Text;
        // }
        return string.Empty;
    }
}