using SiteAcademia.Models;

namespace SiteAcademia.Repositorio.Interfaces
{
    public interface IPersonalRepositorio
    {

        Task<List<PersonalModel>> BuscarTodosPersonais();
        Task<PersonalModel> BuscarPersonalPorId(int id);
        Task<PersonalModel> CadastraPersonal(PersonalModel personal);
        Task<PersonalModel> AtualizarPersonal(PersonalModel personal, int id);
        Task<bool> DeletarPersonal(int id);

    }
}
