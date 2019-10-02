using System;

namespace Model
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        private string _password;
        public string Password
        {
            get { return _password; }

            set { _password = value; }
        }

        public string Firstname { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }



        public User(string username, string firstname,
            string surname, string email, int userid = 0)
        {
            UserID = userid;
            Username = username;
            Firstname = firstname;
            Surname = surname;

            Email = email;

        }
        public User()
        {
        }
        public User(string username, string password)
        {
            Username = username;
            _password = password;
        }

        public void Setpassword(string setpassword)
        {
            this._password = setpassword;
        }

    }
}
