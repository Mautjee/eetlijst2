using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.ModelOld
{
    public class Activity
    {
        public int ActivatyId { get; set; }
        
        public int loggedinUserId { get; set; }
        [ForeignKey("UserId")]
        public User loggedinUser { get; set; }
        
        public int StudentHouseId { get; set; }
        [ForeignKey("StudentHouse")]
        public StudentHouse StudentHouse { get; set; }
        
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int ReceivingUserId { get; set; }
        
        [ForeignKey("ReceivingUserId")]
        public User ReceivingUser { get; set; }


        public Activity()
        {

        }

        public Activity(DateTime date, string description, int amount, int receivinguser,
            int loggedinuser, int studenthouseid)
        {
            Date = date;
            Description = description;
            Amount = amount;
            ReceivingUserId = receivinguser;
            loggedinUserId = loggedinuser;
            StudentHouseId = studenthouseid;
        }
    }
}
