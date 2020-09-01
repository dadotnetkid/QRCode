using QRCode.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using RestSharp;
using Xamarin.Forms;

namespace QRCode.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
            try
            {
                RestRequest restRequest = new RestRequest("", Method.POST);
                RestClient restClient = new RestClient();
                restRequest.AddJsonBody(new
                {
                    grant_type = "password",
                    username = UserName,
                    Password = Password
                });
                await restClient.ExecuteAsync(restRequest);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }


            Application.Current.MainPage = new AppShell();
        }

    }
}
