using Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Interfaces;

namespace Logic
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountRepository _accountrepository;

        public AccountLogic(IAccountRepository accountrepository)
        {
            _accountrepository = accountrepository;
        }

        public QueryFeedback AddAccount(Account account)
        {
            return _accountrepository.AddAccount(account);
        }

        public QueryFeedback AdvanceForRoomate(int[] people, Activaty activaty)
        {
            QueryFeedback feedback = new QueryFeedback();

            int amountOfPeopleToPayInAdvance = people.Length - 1;

            for (int i = 0; i <= amountOfPeopleToPayInAdvance; i++)
            {
                activaty.OtherAccountId = people[i];

                feedback = _accountrepository.AddActivity(activaty);
                if (!feedback.Succes)
                {
                    return feedback;
                }
            }

            return feedback;
        }

        public Task<Account> Authenticate(Account account)
        {
            return _accountrepository.Authenticate(account);
        }

        public QueryFeedback CookForRoommates(int[] people, Activaty activaty)
        {
            QueryFeedback feedback = new QueryFeedback();

            int amountPeople = people.Length + 1;
            int? costPerPerson = activaty.Amount / amountPeople;
            int amountOfGuests = people.Length - 1;


            for (int i = 0; i <= amountOfGuests; i++)
            {
                activaty.Amount = costPerPerson;
                activaty.OtherAccountId = people[i];
                feedback = _accountrepository.AddActivity(activaty);
                if (!feedback.Succes)
                {
                    return feedback;
                }
            }


            return feedback;
        }

        public Account getAccountById(int id)
        {
            return _accountrepository.getAccountById(id);
        }

        public List<Account> GetAllAccounts()
        {
            return _accountrepository.GetAllAccounts();
        }

        public QueryFeedback UpdateAccount(Account account)
        {
            return _accountrepository.UpdateAccount(account);
        }
    }
}
