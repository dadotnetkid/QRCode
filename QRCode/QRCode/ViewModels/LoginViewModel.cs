using QRCode.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Newtonsoft.Json;
using QRCode.Models;
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
                RestRequest restRequest = new RestRequest("token", Method.POST);
                RestClient restClient = new RestClient("http://210.213.232.34:57292");
                restRequest.AddJsonBody(new LoginVM()
                {
                    grant_type = "password",
                    username = UserName,
                    password = Password
                });

                var token = await restClient.PostAsync<AccessTokens>(restRequest);
                var accesstoken = JsonConvert.DeserializeObject<AccessTokens>(token.UserName);
                Application.Current.MainPage = new AppShell();
                await Shell.Current.GoToAsync($"//AboutPage?userName={accesstoken.UserName}");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }



        }

    }
}
