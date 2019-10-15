using System.Collections.Generic;
using System.Diagnostics;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Model;

namespace eetlijst2.Controllers
{
    
    [ApiController]
    [Route("user/[controller]")]
    public class AdminController : ControllerBase
    {
        private UserLogic _userLogic = UserFactory.useMemoryContext();
        
        [HttpGet]
        public List<User> Get()
        {
            return _userLogic.GetAllUseras();
        }
        [HttpGet( "{id}")]
        public User Get(int id)
        {
            return _userLogic.GetbyID(id);
        }
    }
}