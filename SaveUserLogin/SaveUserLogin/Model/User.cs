using System;
using System.Collections.Generic;
using System.Text;

namespace SaveUserLogin.Model {
    public class User {
        public string Email { get; set; }
        public string Senha { get; set; } // é errado salvar a senha, mas é só exemplo XD
    }
}
