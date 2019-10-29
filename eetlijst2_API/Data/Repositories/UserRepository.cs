using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;
using Model.ModelOld;

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

        public Task<User>  Authenticate(User user)
        {
            return _userContext.Authenticate(user);
        }

        public QueryFeedback AddActivity(Activity activity)
        {
            return _userContext.AddActivity(activity);
        }
    }
}