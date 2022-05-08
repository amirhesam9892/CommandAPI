
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CommandAPI.AddControllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class CommandsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"this","is","hard","code"};
        }
    }
}