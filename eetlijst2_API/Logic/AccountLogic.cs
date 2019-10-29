using System;
using Model;
using Data.Repositories;
namespace Logic
{
    public class AccountLogic : IAccountLogic
    {
        private AccountRepository _accountrepository;
        public AccountLogic(AccountRepository accountrepository)
        {
            _accountrepository = accountrepository;
        }

        public Account getAccountById(int id)
        {
            return _accountrepository.getAccountById(id);
        }
    }
}
