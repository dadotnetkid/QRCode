using QRCode.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
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

                var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("username",UserName),
                    new KeyValuePair<string, string>("password",Password),
                    new KeyValuePair<string, string>("grant_type","password")
                };
                var request = new HttpRequestMessage(HttpMethod.Post, "http://210.213.232.34:57292/token");
                request.Content = new FormUrlEncodedContent(keyValues);
                var client = new HttpClient();
                var response = await client.SendAsync(request);
         
                var accesstoken = JsonConvert.DeserializeObject<AccessTokens>(await response.Content.ReadAsStringAsync ());
                if(!string.IsNullOrEmpty(accesstoken.AccessToken))
                {
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync($"//AboutPage?userName={accesstoken.UserName}");
                }    
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }



        }

    }
}
