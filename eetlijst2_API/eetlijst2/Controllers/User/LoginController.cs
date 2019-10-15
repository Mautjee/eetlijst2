using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Logic;
using Factory;
namespace eetlijst2.Controllers
{ 
    [ApiController]
    [Route("user/[controller]")]
    public class loginController : ControllerBase
    {
        private UserLogic _userLogic = UserFactory.useMemoryContext();
        
        [HttpPost]
        public async Task<ActionResult<QueryFeedback>> PostTodoItem(User loginUser)
        {

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            //return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
            return _userLogic.CheckLogin(loginUser);
        }
    }
}