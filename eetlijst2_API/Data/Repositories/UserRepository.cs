using System.Collections.Generic;
using Data.Interfaces;
using Model;

namespace Data.Repositories
{
    public class UserRepository : IUserContext
    {
        readonly IUserContext _userContext;
        
        public UserRepository(IUserContext userContext)
        {
            _userContext = userContext;
        }
        public List<User> GetAllUsers()
        {
            return _userContext.GetAllUsers();
        }

        public User GetbyID(int id)
        {
            return _userContext.GetbyID(id);
        }

        public QueryFeedback AddUser(User user)
        {
            return _userContext.AddUser(user);
        }

        public QueryFeedback UpdateUser(User user)
        {
            return _userContext.UpdateUser(user);
        }

        public QueryFeedback CheckLogin(User user)
        {
            return _userContext.CheckLogin(user);
        }

        public QueryFeedback AddActivity(Activity activity)
        {
            return _userContext.AddActivity(activity);
        }
    }
}