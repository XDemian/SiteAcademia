using Microsoft.EntityFrameworkCore;
using SiteAcademia.Data;
using SiteAcademia.Models;
using SiteAcademia.Repositorio.Interfaces;

namespace SiteAcademia.Repositorio
{
    public class TreinoRepositorio : ITreinoRepositorio
    {

        private readonly SiteAcademiaDBContext _dbContext;
        public TreinoRepositorio(SiteAcademiaDBContext siteAcademiaDBContext)
        {
            _dbContext = siteAcademiaDBContext;
        }

        public async Task<TreinoModel> CadastraTreino(TreinoModel treino)
        {
            if (treino == null)
            {
                throw new ArgumentNullException("Treino está Nulo");
            }

            await _dbContext.Treinos.AddAsync(treino);
                await _dbContext.SaveChangesAsync();
 
            return treino;
        }
        public async Task<TreinoModel> AtualizarTreino(TreinoModel treino, int id)
        {
            if (treino == null)
            {
                throw new ArgumentNullException("Treino está Nulo");
            }

            TreinoModel treinoPorId = await BuscarTreinoPorId(id);
            
            if (treinoPorId == null) 
            {
                throw new ArgumentNullException("Treino Não Localizado");
            }
            
            treinoPorId.Cliente = treino.Cliente;
            treinoPorId.Exercicios = treino.Exercicios;
            treinoPorId.Observacoes = treino.Observacoes;
            treinoPorId.Data = treino.Data;

            _dbContext.Treinos.Update(treinoPorId);
            _dbContext.SaveChangesAsync();

            return treinoPorId;
           
        }

        public async Task<List<TreinoModel>> BuscarTodosTreinos()
        {
            List<TreinoModel> treinos = await _dbContext.Treinos.ToListAsync();

            if (treinos.Count == 0) 
            {
                throw new Exception("Treinos não Localizados");
            }

            return treinos;
        }

        public async Task<TreinoModel> BuscarTreinoPorId(int id)
        {
          TreinoModel treino = await _dbContext.Treinos.FirstOrDefaultAsync(x => x.Id == id);

            if (treino == null)
            {
                throw new Exception($"Treino {id} Não localizado");
            }

            return treino;
        }

        public async Task<bool> DeletarTreino(int id)
        {
            TreinoModel treinoDeletado = await  BuscarTreinoPorId(id);

            _dbContext.Treinos.Remove(treinoDeletado);
           await  _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
