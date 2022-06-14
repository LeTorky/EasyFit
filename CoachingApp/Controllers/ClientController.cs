using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoachingApp.Interfaces;
using CoachingApp.DTO;

namespace CoachingApp.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClientManager _clientManager;
        public ClientController(IClientManager clientManager)
        {
            _clientManager = clientManager;
        }
        [HttpPost]
       public IActionResult CreateClient(ClientUserDTO ClientUser,Guid id)
        {
            var client = _clientManager.CreateClient(ClientUser, id);
            if( client!= null)
            {
                return Ok(client);
            }
            else { return BadRequest(); }
        }
        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            if (_clientManager.GetClientById(id) == null)
                return NotFound();
            return Ok(_clientManager.GetClientById(id));
        }
        [HttpGet]
        public IActionResult GetAllClients()
        {
            if (_clientManager.GetAllClients() == null)
                return NotFound();
            return Ok(_clientManager.GetAllClients());
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            if (_clientManager.DeleteClient(id) == null)
                return NotFound();
            return Ok(_clientManager.DeleteClient(id));
        }
        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id,ClientUserDTO obj)
        {
            if (_clientManager.UpdateClient(id,obj) == null)
                return NotFound();
            return Ok(_clientManager.UpdateClient(id,obj));
        }
        [HttpGet]
        public  IActionResult GetProfile(int id)
        {
            if ( _clientManager.GetClientProfile(id) == null)
                return NotFound();
            return Ok( _clientManager.GetClientProfile(id));
        }
        [HttpGet]
        public IActionResult GetAllByWork()
        {
            if (_clientManager.GetAllByWorkOut() == null)
                return NotFound();
            return Ok(_clientManager.GetAllByWorkOut());
        }
    }
}
