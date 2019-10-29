using System;
using System.Linq;
using Model;
using Data.Interfaces;
namespace Data.Contexts
{
    public class AccountSqlContext : IAccountContext
    {
        private mauro_sqlContext context = new mauro_sqlContext();

        public Account getAccountById(int id)
        {
            var account = context.Account.Where(s => s.AccountId == id).FirstOrDefault();

            return account;

        }
    }
}
