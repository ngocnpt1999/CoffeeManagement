using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlycafe
{
    class User
    {
        private string username;
        private string password;
        private string fullName;
        private int truycap;

        public User(string username, string password, string fullName, int truycap)
        {
            this.username = username;
            this.password = password;
            this.fullName = fullName;
            this.truycap = truycap;
        }

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public int Truycap { get => truycap; set => truycap = value; }
    }
}
