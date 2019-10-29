using System;
using Data.Interfaces;
using Model;

namespace Data.Repositories
{
    public class AccountRepository : IAccountContext
    {
        private IAccountContext _accountContext;

        public AccountRepository(IAccountContext accountContext)
        {
            _accountContext = accountContext;
        }

        public Account getAccountById(int id)
        {
           return  _accountContext.getAccountById(id);
        }
    }
}
