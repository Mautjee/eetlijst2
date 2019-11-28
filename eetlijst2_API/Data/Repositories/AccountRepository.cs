using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Contexts;
using Data.Interfaces;
using Model;

namespace Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly mauro_sqlContext _mauroContext;

        public AccountRepository(mauro_sqlContext mauro_SqlContext)
        {
            _mauroContext = mauro_SqlContext;
        }

        public QueryFeedback AddActivity(Activaty activity)
        {
            var feedback = new QueryFeedback();
            try
            {
                _mauroContext.Activaty.Add(activity);

                _mauroContext.SaveChanges();

                feedback.Succes = true;
                feedback.Message = "Activity is added";
            }
            catch
            {
                feedback.Succes = false;
                feedback.Message = "Somthing went wrong adding this account";
            }
            return feedback;
        }

        public QueryFeedback AddAccount(Account account)
        {
            var feedback = new QueryFeedback();
            try
            {
                _mauroContext.Account.Add(account);

                _mauroContext.SaveChanges();

                feedback.Succes = true;
                feedback.Message = "User is added";
            }
            catch
            {
                feedback.Succes = false;
                feedback.Message = "Somthing went wrong adding this account";
            }
            return feedback;
        }

        public async Task<Account> Authenticate(Account account)
        {
            var loggedInAccount = await Task.Run(() => 
                _mauroContext.Account.FirstOrDefault(s => s.Username == account.Username 
                                                          & s.Password == account.Password));

            if (loggedInAccount == null)
                return null;

            loggedInAccount.Password = null;

            return loggedInAccount;

        }

        public Account getAccountById(int id)
        {
            var account = _mauroContext.Account
                .Where(s => s.AccountId == id)
                .FirstOrDefault();

            return account;

        }

        public List<Account> GetAllAccounts()
        {
            return _mauroContext.Account.ToList();
        }

        public QueryFeedback UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
