using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuggyController : ControllerBase
    {

        [HttpGet("notfound")]  //  GET : api/Buggy/notfound
        public IActionResult GetNotFoundRequest()
        {
            // logic of code 
            return NotFound();  // 404 -> not found result
        }


        [HttpGet("servererror")]  //  GET : api/Buggy/servererror
        public IActionResult GetServerErrorRequest()
        {
            // logic of code 
            // Exception
            throw new Exception();   // 500 
            return Ok(); 
        }


        [HttpGet( template:"badrequest")]  //  GET : api/Buggy/baderequest
        public IActionResult GetBadRequest()
        {
            // logic of code 
          return BadRequest();  // 400  
        }


        [HttpGet( template: "badrequest/{id}")]  //  GET : api/Buggy/baderequest/mariam
        public IActionResult GetBadRequest(int id)  // Validation Error
        {
            // logic of code 
            return BadRequest();  // 400  
        }


        [HttpGet(template: "unauthorized")]  //  GET : api/Buggy/unauthorized
        public IActionResult GetUnauthorizedRequest(int id)  // Validation Error
        {
            // logic of code 
            return Unauthorized();  // 401  
        }


    }
}
