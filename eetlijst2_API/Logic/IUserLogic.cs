using System;
using System.Collections.Generic;
using Model;

namespace Logic
{
    public interface IUserLogic
    {
        List<User> GetAllUseras();
        User GetbyID(int id);
        QueryFeedback AddUser(User user);
        QueryFeedback UpdateUser(User user);
        User CheckLogin(User user);
        QueryFeedback AdvanceForRoomate(int[] people, Activity activaty);
        QueryFeedback CookForRoommates(int[] people, Activity activaty);

    }
}
