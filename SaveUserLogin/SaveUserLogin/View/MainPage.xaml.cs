using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveUserLogin.View {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage:ContentPage {
        public MainPage () {
            InitializeComponent();

            BindingContext = new ViewModel.MainPageViewModel(this);
        }
    }
}