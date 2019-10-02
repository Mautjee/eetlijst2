using System;
namespace Model
{
    public class Activity
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int ReceivingUser { get; set; }
        public int LoggedInUser { get; set; }
        public int StudentHouseID { get; set; }

        public Activity()
        {

        }

        public Activity(DateTime date, string description, int amount, int receivinguser,
            int loggedinuser, int studenthouseid)
        {
            Date = date;
            Description = description;
            Amount = amount;
            ReceivingUser = receivinguser;
            LoggedInUser = loggedinuser;
            StudentHouseID = studenthouseid;
        }
    }
}
