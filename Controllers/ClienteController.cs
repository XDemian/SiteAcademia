using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteAcademia.Models;
using SiteAcademia.Repositorio.Interfaces;

namespace SiteAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteRepositorio _clienteRepositorio;

        public ClienteController(IClienteRepositorio clienteRepositorio) 
        {
            _clienteRepositorio = clienteRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<ClienteModel>> CadastrarCliente(ClienteModel clienteModel)
        {
           ClienteModel cliente = await _clienteRepositorio.CadastraCliente(clienteModel);
            return Ok(cliente);
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteModel>>> BuscarTodosClientes() 
        {
            List<ClienteModel> clientes = await _clienteRepositorio.BuscarTodosCliente();
            return Ok(clientes);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteModel>> BuscarClientePorID(int id)
        {
            ClienteModel cliente = await  _clienteRepositorio.BuscarClientePorId(id);
            return Ok(cliente);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteModel>> AtualizarCliente([FromBody] ClienteModel clienteModel, int id)
        {
            clienteModel.Id = id;
            ClienteModel clienteAtualizado = await _clienteRepositorio.AtualizarCliente(clienteModel, id);
            return Ok(clienteAtualizado);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ClienteModel>> DeletarCliente(int id)
        {
            bool apagado  = await  _clienteRepositorio.DeletarCliente(id);
            return Ok(apagado);
        }


    

    }
}
