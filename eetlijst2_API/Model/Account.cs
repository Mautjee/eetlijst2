using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Account
    {
        public Account()
        {
            AccountActivaty = new HashSet<AccountActivaty>();
            Activaty = new HashSet<Activaty>();
            Credits = new HashSet<Credits>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MailAdress { get; set; }

        public virtual ICollection<AccountActivaty> AccountActivaty { get; set; }
        public virtual ICollection<Activaty> Activaty { get; set; }
        public virtual ICollection<Credits> Credits { get; set; }
    }
}
