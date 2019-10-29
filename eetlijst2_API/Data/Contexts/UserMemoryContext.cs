using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interfaces;
using Model;
using Model.ModelOld;

namespace Data.Contexts
{
    public class UserMemoryContext : IUserContext
    {
        
        private List<User> users = new List<User>();
        private int userid = 1;
        public UserMemoryContext()
        {
            if (users.Count == 0)
            {
                users.Add(new User("mautjee","1234", "Mauro", "Eijsenring",
                    "mauro@eijsnering.com",userid++));
                
                users.Add(new User( "johnie","1234", "John", "Doe",
                    "john@Doe.com", userid++));
            }
        }
        
        public List<User> GetAllUsers()
        {
            return users;
        }

        public User GetbyID(int id)
        {
            IEnumerable<User> g = from User in users
                where User.UserId == id
                select User;
            return g.ToList()[0];
        }

        public QueryFeedback AddUser(User user)
        {
            
            users.Add(user);
            QueryFeedback feedback = new QueryFeedback(true,"User is added");
            return feedback;
        }

        public QueryFeedback UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> Authenticate(User u)
        {

            var user = await Task.Run(() =>
                users.SingleOrDefault(x => x.Username == u.Username && x.Password == u.Password));

            if (user == null)
                return null;

            user.Password = null;
            return user;
        }

        public QueryFeedback AddActivity(Activity activity)
        {
            throw new System.NotImplementedException();
        }
    }
}