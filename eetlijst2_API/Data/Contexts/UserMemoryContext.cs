using System.Collections.Generic;
using System.Linq;
using Data.Interfaces;
using Model;

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
                where User.UserID == id
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

        public QueryFeedback CheckLogin(User user)
        {
            QueryFeedback Data = new QueryFeedback();

            try
            {
                IEnumerable<User> g = from U in users
                    where U.Username == user.Username
                    select U;
                User us = g.ToList()[0];
                
                if (user.Username == us.Username && user.Password == us.Password)
                {
                    Data.Succes = true;
                    Data.Message = "User is logged in";
                    return Data;
                }
                else
                {
                    Data.Succes = false;
                    Data.Message = "Wrong Username or password";
                    return Data;
                }
            }
            catch
            {
                Data.Succes = false;
                Data.Message = "Wrong Username or password";
                return Data;
            }
        }

        public QueryFeedback AddActivity(Activity activity)
        {
            throw new System.NotImplementedException();
        }
    }
}