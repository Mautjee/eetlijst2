using System.Threading.Tasks;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Model;
namespace eetlijst2.Controllers
{
    [ApiController]
    [Route("user/[controller]")]
    public class ModifyController : ControllerBase
    {
        private UserLogic _userLogic = UserFactory.useMemoryContext();

        [HttpPost]
        public async Task<ActionResult<QueryFeedback>> PostTodoItem(User loginUser)
        {
            return _userLogic.AddUser(loginUser);
        }
    }
}