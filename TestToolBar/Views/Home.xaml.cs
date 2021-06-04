using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestToolBar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestToolBar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            BindingContext = new HomeViewModel();
            InitializeComponent();
        }
    }
}