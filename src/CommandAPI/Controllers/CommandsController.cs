
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI.AddControllers
{
        [Route("api/[controller]")]
        [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> GetAllCommands()
        {
            //return new string[] {"this","is","hard","code"};
            var commandItems = _repository.GetAllCommands();
            return Ok(commandItems);
        }
        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem == null )
            {
                return NotFound();
            }
            return Ok(commandItem);
        }
    }
}