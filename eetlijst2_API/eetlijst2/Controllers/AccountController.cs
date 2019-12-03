using System;
using eetlijst2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Model;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace eetlijst2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase 
    {
        //private AccountLogic _accountLogic = AccountFactory.accountSql();
        private readonly IAccountLogic _accountLogic;
        private readonly ILoginService _loginService;

        public AccountController(IAccountLogic accountLogic,ILoginService loginService)
        {
            _accountLogic = accountLogic;
            _loginService = loginService;
        }
        
        [HttpGet("/api/[controller]/{id}")]
        [Authorize(Roles = "Admin")]
        public Account Get(int id)
        {
            return _accountLogic.getAccountById(id);
        }
        
      
        [HttpPost("/api/[controller]/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public ActionResult<QueryFeedback> Post([FromBody] Account account)
        {
//            if (!ModelState.IsValid) return BadRequest("Invalid model");
            var token =  _loginService.Login(account).Result;
            if (token == null) 
                return BadRequest("Authentication Error");
            HttpContext.Session.SetString("JWToken", token);
            return Ok(token);
        }
    }
}
