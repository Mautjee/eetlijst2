using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Credits
    {
        public int AccountId { get; set; }
        public int StudenthouseId { get; set; }
        public int Credit { get; set; }

        public virtual Account Account { get; set; }
        public virtual Studenthouse Studenthouse { get; set; }
    }
}
