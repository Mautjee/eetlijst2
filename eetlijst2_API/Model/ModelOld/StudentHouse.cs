using System;
using System.Collections.Generic;

namespace Model.ModelOld
{
    public class StudentHouse
    {
        public int StudenthouseId { get; set; }
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
