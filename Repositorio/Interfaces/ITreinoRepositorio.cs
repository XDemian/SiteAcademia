using SiteAcademia.Models;

namespace SiteAcademia.Repositorio.Interfaces
{
    public interface ITreinoRepositorio
    {

        Task<List<TreinoModel>> BuscarTodosTreinos();
        Task<TreinoModel> BuscarTreinoPorId(int id);
        Task<TreinoModel> CadastraTreino(TreinoModel treino);
        Task<TreinoModel> AtualizarTreino(TreinoModel treino, int id);

        Task<bool> DeletarTreino(int id);

    }
}
