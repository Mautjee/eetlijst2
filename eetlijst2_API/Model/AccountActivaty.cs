using System;
using System.Collections.Generic;

namespace Model
{
    public partial class AccountActivaty
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int StudenthouseId { get; set; }
        public DateTime? In { get; set; }
        public DateTime? Out { get; set; }

        public virtual Account Account { get; set; }
        public virtual Studenthouse Studenthouse { get; set; }
    }
}
