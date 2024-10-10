using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteAcademia.Models;
using SiteAcademia.Repositorio.Interfaces;

namespace SiteAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {

        private readonly IPersonalRepositorio _personalRepositorio;

        public PersonalController(IPersonalRepositorio IPersonalRepositorio) 
        {
            _personalRepositorio = IPersonalRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<PersonalModel>> CadastrarPersonal(PersonalModel personalModel)
        {
           PersonalModel personal = await _personalRepositorio.CadastraPersonal(personalModel);
            return Ok(personal);
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonalModel>>> BuscarTodospersonais() 
        {
            List<PersonalModel> personals = await _personalRepositorio.BuscarTodosPersonais();
            return Ok(personals);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalModel>> BuscarPersonalPorID(int id)
        {
            PersonalModel personal = await  _personalRepositorio.BuscarPersonalPorId(id);
            return Ok(personal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonalModel>> AtualizarCliente([FromBody] PersonalModel personalModel, int id)
        {
            personalModel.Id = id;
            PersonalModel personalAtualizado = await _personalRepositorio.AtualizarPersonal(personalModel, id);
            return Ok(personalAtualizado);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonalModel>> DeletarPersonal(int id)
        {
            bool apagado  = await  _personalRepositorio.DeletarPersonal(id);
            return Ok(apagado);
        }


    

    }
}
