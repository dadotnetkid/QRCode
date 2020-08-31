using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QRCode.Services
{
    public class QRCodeGeneratorService
    {
      public  ZXingBarcodeImageView GenerateQR(string codeValue)
        {
            var qrCode = new ZXingBarcodeImageView
            {
                BarcodeFormat = BarcodeFormat.QR_CODE,
                BarcodeOptions = new QrCodeEncodingOptions
                {
                    Height = 350,
                    Width = 350
                },
                BarcodeValue = codeValue,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            // Workaround for iOS
            qrCode.WidthRequest = 350;
            qrCode.HeightRequest = 350;
            return qrCode;
        }
    }
}
