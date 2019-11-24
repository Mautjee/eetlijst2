using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Logic;
using Microsoft.AspNetCore.Routing;
using Model;

namespace eetlijst2.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class DataController
    {
        private readonly IStudenthouseLogic _studenthouseLogic;

        public DataController(IStudenthouseLogic studenthouseLogic)
        {
            _studenthouseLogic = studenthouseLogic;
        }
        
        [HttpGet]
        [Route("studenthouses")]
        public List<Studenthouse> Get(int id)
        {
            return _studenthouseLogic.GetallStudenthouses();
        }
    }
}