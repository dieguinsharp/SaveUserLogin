using SaveUserLogin.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace SaveUserLogin.ViewModel {
    public class MainPageViewModel : INotifyPropertyChanged {

        public Command SairCommand { get; set; }

        ContentPage page;
        public MainPageViewModel (ContentPage page) {

            SairCommand = new Command(ClickSair);
            this.page = page;
        }

        public async void ClickSair () {

            App.UserBd.DeleteUser();

            page.Navigation.InsertPageBefore(new LoginPage(), this.page);
            await page.Navigation.PopAsync();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
