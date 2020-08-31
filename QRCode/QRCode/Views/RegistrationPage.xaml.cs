using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCode.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QRCode.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
        protected override bool OnBackButtonPressed()
        {
            Application.Current.MainPage = new LoginPage();
            return true;
        }
    }
}