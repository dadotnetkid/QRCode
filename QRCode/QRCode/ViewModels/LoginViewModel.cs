using QRCode.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QRCode.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private async void OnRegisterClicked(object obj)
        {
            Application.Current.MainPage = new RegistrationPage();
        }

        private async void OnLoginClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            Application.Current.MainPage = new AppShell();
        }

    }
}
