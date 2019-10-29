using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Activaty
    {
        public int ActivatyId { get; set; }
        public int AccountId { get; set; }
        public int StudenthouseId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public int? Amount { get; set; }
        public int OtherAccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual Studenthouse Studenthouse { get; set; }
    }
}
