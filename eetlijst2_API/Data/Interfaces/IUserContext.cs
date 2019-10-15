using System;
using System.Collections.Generic;
using Model;

namespace Data.Interfaces
{
    public interface IUserContext
    {
        List<User> GetAllUsers();
        User GetbyID(int id);
        QueryFeedback AddUser(User user);
        QueryFeedback UpdateUser(User user);
        QueryFeedback CheckLogin(User user);
        QueryFeedback AddActivity(Activity activity);
    }
}
