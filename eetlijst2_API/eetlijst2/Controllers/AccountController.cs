using System;
using Microsoft.AspNetCore.Mvc;
using Model;
using Logic;
namespace eetlijst2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController
    {
        //private AccountLogic _accountLogic = AccountFactory.accountSql();
        private readonly IAccountLogic _accountLogic;

        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _accountLogic.getAccountById(id);
        }

        //[HttpPost]
        //public QueryFeedback authenticate(Account account)
        //{
            
        //}
    }
}
