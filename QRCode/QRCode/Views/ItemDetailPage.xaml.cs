using System.ComponentModel;
using Xamarin.Forms;
using QRCode.ViewModels;

namespace QRCode.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}