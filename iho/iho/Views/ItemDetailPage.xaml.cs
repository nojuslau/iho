using iho.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace iho.Views
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