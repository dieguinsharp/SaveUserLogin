using Newtonsoft.Json;
using SaveUserLogin.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace SaveUserLogin.Util {
    public class UserBd {

        string userJson;
        public static User UserLogado;

        public User GetUser () {

            userJson = Preferences.Get("User", "");
            UserLogado = JsonConvert.DeserializeObject<User>(userJson);

            return UserLogado;
        }

        public void SetUser(User user) {

            if(Preferences.ContainsKey("User","")) {
                Preferences.Remove("User");
            }

            userJson = JsonConvert.SerializeObject(user);
            Preferences.Set("User",userJson);

            UserLogado = user;
        }

        public void DeleteUser() {

            Preferences.Remove("User");

        }

    }
}
