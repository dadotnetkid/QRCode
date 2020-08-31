using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCode.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QRCodePage : ContentPage
    {
        public QRCodePage()
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