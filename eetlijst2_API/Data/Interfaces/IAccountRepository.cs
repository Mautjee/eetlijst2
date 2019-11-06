using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;


namespace Data.Interfaces
{
    public interface IAccountRepository
    {

        List<Account> GetAllAccounts();
        Account getAccountById(int id);
        QueryFeedback AddAccount(Account account);
        QueryFeedback UpdateAccount(Account account);
        Task<Account> Authenticate(Account account);
        QueryFeedback AddActivity(Activaty activity);
    }
}
