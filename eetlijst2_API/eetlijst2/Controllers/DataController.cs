using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Model;

namespace eetlijst2.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IStudenthouseLogic _studenthouseLogic;

        public DataController(IStudenthouseLogic studenthouseLogic)
        {
            _studenthouseLogic = studenthouseLogic;
        }
        
        [HttpGet("studenthouse")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<List<Studenthouse>> GetAllStudenthouses()
        {
           
            var listStudenthouse = _studenthouseLogic.GetallStudenthouses();
            return Ok(listStudenthouse);
        }

        [HttpPost("studenthouse/resedent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<QueryFeedback> Post([FromBody] StudUserId data)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid model");
            
            return _studenthouseLogic.AddResident(data.UserId,data.StudenthouseId);
        }

        [HttpGet("{id}/Studenthouse/")]
        public ActionResult<VwActiveStudenthouseAccount> GetActiveStudenthouse(int userId)
        {
            var studenthouse = _studenthouseLogic.GetCurrentStudenthouse(userId);
            return Ok(studenthouse);
        }

    }
}