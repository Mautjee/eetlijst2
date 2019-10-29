using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model.ModelOld;

namespace Logic
{
    public interface IUserLogic
    {
        List<User> GetAllUseras();
        User GetbyID(int id);
        QueryFeedback AddUser(User user);
        QueryFeedback UpdateUser(User user);
        Task<User>  Authenticate(User user);
        QueryFeedback AdvanceForRoomate(int[] people, Activity activaty);
        QueryFeedback CookForRoommates(int[] people, Activity activaty);

    }
}
