using System.Threading.Tasks;
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
    public class ModifyController : ControllerBase
    {
        private UserLogic _userLogic = UserFactory.useMemoryContext();

        [HttpPost]
        public  ActionResult<QueryFeedback> PostnewUser(User newUser)
        {
            
            return _userLogic.AddUser(newUser);
        }
    }
}