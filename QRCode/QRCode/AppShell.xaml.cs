using System;
using System.Collections.Generic;
using QRCode.ViewModels;
using QRCode.Views;
using Xamarin.Forms;

namespace QRCode
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute("login", typeof(LoginPage));
            Shell.Current.GoToAsync("///login");
        }
        async void Init()
        {
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
