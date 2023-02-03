using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Test.Models;
using WebApi_Test.Repository.Interfaces;

namespace WebApi_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<ClientModel>>> GetAllClients()
        {
            List<ClientModel> usuarios = await _clientRepository.ListAllClients();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> SearchClientById(int id)
        {
            ClientModel client = await _clientRepository.GetClientById(id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<ClientModel>> AddClient([FromBody] ClientModel clientModel)
        {
            ClientModel newClient = await _clientRepository.AddClient(clientModel);
            return Ok(newClient);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> UpdateClientInfos([FromBody]ClientModel clientModel , int id)
        {
            clientModel.Id = id;
            ClientModel client = await _clientRepository.UpdateClient(clientModel, id);
            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> DeleteClient(int id)
        {
            bool deleted = await _clientRepository.DeleteClient(id);
            return Ok(deleted);
        }
    }
}
