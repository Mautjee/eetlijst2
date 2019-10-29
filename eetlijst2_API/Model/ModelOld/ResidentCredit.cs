using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModelOld
{
    public class ResidentCredit
    {
        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User resident { get; set; }
        
        public int StudentHouseId { get; set; }
        [ForeignKey("StudentHouseId")]
        public StudentHouse StudentHouse { get; set; }
        
        public int Credit { get; set; }
    }
}
