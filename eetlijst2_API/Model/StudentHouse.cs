using System;
using System.Collections.Generic;

namespace Model
{
    public class StudentHouse
    {
        public int StudenthouseID { get; set; }
        public string Name { get; set; }
        public List<User> Residents { get; set; }

        public StudentHouse()
        {

        }

        public bool VoegBewonerToe(User user)
        {
            Residents.Add(user);
            return true;
        }
    }
}
