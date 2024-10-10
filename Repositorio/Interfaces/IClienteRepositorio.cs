using SiteAcademia.Models;

namespace SiteAcademia.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {

        Task<List<ClienteModel>> BuscarTodosCliente();
        Task<ClienteModel> BuscarClientePorId(int id);
        Task<ClienteModel> CadastraCliente(ClienteModel treino);
        Task<ClienteModel> AtualizarCliente(ClienteModel treino, int id);
        Task<bool> DeletarCliente(int id);

    }
}
