using System;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;
using QRCode.Services;
using QRCode.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRCode.Views
{
    [QueryProperty("UserName", "userName")]
    public partial class AboutPage : ContentPage
    {
        public string pnlmodel
        {
            set
            {
                string derulo = Uri.UnescapeDataString(value);
               

            }
        }
        public AboutPage()
        {
            InitializeComponent();
        }

        private async void BtnScan_Clicked(object sender, EventArgs e)
        {
            try
            {
  
                var scanner = DependencyService.Get<IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null)
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(result);
                    var text = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
                    var res = JsonConvert.DeserializeObject<Logs>(text);
      
                    QRCodeGeneratorService qrGent = new QRCodeGeneratorService();
                    var qr = qrGent.GenerateQR(
                        System.Convert.ToBase64String(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(res))));
                    stack.Children.Add(qr);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}