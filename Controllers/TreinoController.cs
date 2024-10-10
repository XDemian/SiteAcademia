using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteAcademia.Models;
using SiteAcademia.Repositorio.Interfaces;

namespace SiteAcademia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TreinoController : ControllerBase
    {

        private readonly ITreinoRepositorio _treinoRepositorio;

        public TreinoController(ITreinoRepositorio treinoRepositorio) 
        {
            _treinoRepositorio = treinoRepositorio;
        }

        [HttpPost]
        public async Task<ActionResult<TreinoModel>> Cadastrartreino(TreinoModel treinoModel)
        {
           TreinoModel treino = await _treinoRepositorio.CadastraTreino(treinoModel);
            return Ok(treino);
        }

        [HttpGet]
        public async Task<ActionResult<List<TreinoModel>>> BuscarTodosTreinos() 
        {
            List<TreinoModel> treinos = await _treinoRepositorio.BuscarTodosTreinos();
            return Ok(treinos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TreinoModel>> BuscarTreinoPorID(int id)
        {
            TreinoModel treinoPorId = await _treinoRepositorio.BuscarTreinoPorId(id);
            return Ok(treinoPorId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TreinoModel>> AtualizarCliente([FromBody] TreinoModel treinoModel, int id)
        {
            treinoModel.Id = id;
            TreinoModel treinoAtualizado = await _treinoRepositorio.AtualizarTreino(treinoModel, id);
            return Ok(treinoAtualizado);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<TreinoModel>> DeletarPersonal(int id)
        {
            bool apagado  = await  _treinoRepositorio.DeletarTreino(id);
            return Ok(apagado);
        }


    

    }
}
