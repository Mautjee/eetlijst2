using System;
using Microsoft.AspNetCore.Mvc;
using Model;
using Logic;
using Factory;
namespace eetlijst2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController
    {
        private AccountLogic _accountLogic = AccountFactory.accountSql();


        [HttpGet("{id}")]
        public Account Get(int id)
        {
            return _accountLogic.getAccountById(id);
        }
    }
}
