using QRCode.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace QRCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            ContainerLayout.Children.Add(
            new QRCodeGeneratorService().GenerateQR(
                "ewogICJGaXJzdE5hbWUiOiJNYXJrIENocmlzdG9waGVyIiwKICAiTGFzdE5hbWUiOiJDYWNhbCIsCn0="));
        }
    }
}