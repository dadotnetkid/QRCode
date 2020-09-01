using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCode.ViewModels;
using RestSharp;
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

        private async void btnRegister(object sender, EventArgs e)
        {
            try
            {
                RestClient restClient = new RestClient("http://");
                RestRequest restRequest = new RestRequest();
                restRequest.AddJsonBody(new
                {
                    Email = txtEmail.Text,
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Password = txtPassword.Text
                });
                await restClient.ExecuteAsync(restRequest);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }
    }
}