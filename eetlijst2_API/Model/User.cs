using System;

namespace Model
{
    public class User
    {
        public int UserID { get; set; }

        public string Username { get; set; }
        
        public string Password { get; set; }

        public string Firstname { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }



        public User(string username,string password,string firstname,
            string surname, string email, int userid = 0)
        {
            UserID = userid;
            Username = username;
            Firstname = firstname;
            Surname = surname;
            Password = password;
            Email = email;

        }
        public User()
        {
        }
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void Setpassword(string setpassword)
        {
            Password = setpassword;
        }

    }
}
