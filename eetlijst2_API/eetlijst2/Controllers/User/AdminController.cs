using System.Collections.Generic;
using System.Diagnostics;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Microsoft.AspNetCore.Authorization;
using Model.ModelOld;

namespace eetlijst2.Controllers
{
    //[Authorize]
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