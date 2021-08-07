using SaveUserLogin.Util;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SaveUserLogin {
    public partial class App:Application {

        private static UserBd _userBd;

        public App () {
            InitializeComponent();

            _userBd = new UserBd();

            if(UserBd.GetUser() != null) {
                MainPage = new NavigationPage(new View.MainPage());
            } else {
                MainPage = new NavigationPage(new View.LoginPage());
            }
            
        }

        public static UserBd UserBd {
            get { return _userBd; }
        }

        protected override void OnStart () {
        }

        protected override void OnSleep () {
        }

        protected override void OnResume () {
        }
    }
}
