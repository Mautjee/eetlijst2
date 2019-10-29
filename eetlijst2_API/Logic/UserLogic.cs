using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Repositories;
using Model.ModelOld;

namespace Logic
{
    public class UserLogic : IUserLogic
    {
        private UserRepository _userRepository;

        public UserLogic(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<User> GetAllUseras()
        {
           return _userRepository.GetAllUsers();
        }

        public User GetbyID(int id)
        {
            return _userRepository.GetbyID(id);
        }

        public QueryFeedback AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public QueryFeedback UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }

        public Task<User>  Authenticate(User user)
        {
            return _userRepository.Authenticate(user);
        }

        public QueryFeedback AdvanceForRoomate(int[] people, Activity activaty)
        {
            QueryFeedback feedback = new QueryFeedback();

            int amountOfPeopleToPayInAdvance = people.Length - 1;

            for (int i = 0; i <= amountOfPeopleToPayInAdvance; i++)
            {
                activaty.ReceivingUserId = people[i];

                feedback = _userRepository.AddActivity(activaty);
                if (!feedback.Succes)
                {
                    return feedback;
                }
            }

            return feedback;
        }

        public QueryFeedback CookForRoommates(int[] people, Activity activaty)
        {
            QueryFeedback feedback = new QueryFeedback();

            int amountPeople = people.Length + 1;
            int costPerPerson = activaty.Amount / amountPeople ;
            int amountOfGuests = people.Length - 1;
            
            
            for(int i = 0; i <= amountOfGuests; i++)
            {
                activaty.Amount = costPerPerson;
                activaty.ReceivingUserId = people[i];
                feedback = _userRepository.AddActivity(activaty);
                if (!feedback.Succes)
                {
                    return feedback;
                }
            }
            

            return feedback;
        }
    }
}