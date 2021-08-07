using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;
using SaveUserLogin.Model;
using SaveUserLogin.View;

namespace SaveUserLogin.ViewModel {
    class LoginViewModel:INotifyPropertyChanged {

        public Command LoginCommand { get; set; }

        bool _isBusy;
        public bool IsBusy { get {
            return _isBusy;
            } set {
                _isBusy = value; NotifyPropertyChanged(nameof(IsBusy));
            }
        }

        string _email;
        public string Email { get {
            return _email;
            } set {
                _email = value; NotifyPropertyChanged(nameof(Email));
            }
        }

        string _senha;
        public string Senha { get {
            return _senha;
            } set {
                _senha = value; NotifyPropertyChanged(nameof(Senha));
            }
        }

        ContentPage page;
        public LoginViewModel (ContentPage page) {

            LoginCommand = new Command(ClickLogin);
            this.page = page;

        }

        public async void ClickLogin () {

            if(!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Senha)) {

                IsBusy = true;

                await Task.Run(() => {

                    Task.Delay(2000);

                    User user = new User() {
                        Email = Email,
                        Senha = Senha
                    };

                    App.UserBd.SetUser(user);

                    Device.BeginInvokeOnMainThread(() => { 

                        this.page.Navigation.InsertPageBefore(new MainPage(), this.page);
                        this.page.Navigation.PopAsync();
                        
                    });

                });

                IsBusy = false;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
