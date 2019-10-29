
using Data.Contexts;
using Data.Repositories;
using Logic;
namespace Factory
{
    public class AccountFactory
    {
        public static AccountLogic accountSql()
        {
            return new AccountLogic(new AccountRepository(new AccountSqlContext()));
        }
    }
}
