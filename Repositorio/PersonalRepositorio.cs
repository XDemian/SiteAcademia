using Microsoft.EntityFrameworkCore;
using SiteAcademia.Data;
using SiteAcademia.Models;
using SiteAcademia.Repositorio.Interfaces;

namespace SiteAcademia.Repositorio
{
    public class PersonalRepositorio: IPersonalRepositorio
    {
        private readonly SiteAcademiaDBContext _dbContext;

        public PersonalRepositorio(SiteAcademiaDBContext siteAcademiaDBContext)
        {
            _dbContext = siteAcademiaDBContext;
        }

        public async Task<PersonalModel> CadastraPersonal(PersonalModel personal)
        {
           await _dbContext.Personais.AddAsync(personal);
            _dbContext.SaveChanges();
            return personal;
        } 

        public async Task<PersonalModel> AtualizarPersonal(PersonalModel personal, int id)
        {
            PersonalModel PersonalPorId = await BuscarPersonalPorId(id);
            
            if (PersonalPorId == null) 
            {
                throw new Exception("Personal não localizado");
            }

            PersonalPorId.Nome = personal.Nome;
            PersonalPorId.ImagemUrl = personal.ImagemUrl;
            PersonalPorId.Descricao = personal.Descricao;
            PersonalPorId.Contato = personal.Contato;

            _dbContext.Personais.Update(PersonalPorId);
           await _dbContext.SaveChangesAsync();
           
            return PersonalPorId;
        }

        public async Task<PersonalModel> BuscarPersonalPorId(int id)
        {
          PersonalModel personalPorId  = await _dbContext.Personais.FirstOrDefaultAsync(x => x.Id == id);

            if (personalPorId == null)
            {
                throw new Exception("Pesonal não localizado");
            }

            return personalPorId;
        }

        public async Task<List<PersonalModel>> BuscarTodosPersonais()
        {
            List<PersonalModel> personais = await _dbContext.Personais.ToListAsync();

            if (personais.Count == 0)
            {
                throw new Exception("Personais não cadastrados, Lista Vazia");
            }

            return personais;
        }

        public async Task<bool> DeletarPersonal(int id)
        {
           PersonalModel personalDeletar = await BuscarPersonalPorId(id);

            if (personalDeletar == null) 
            {
                throw new Exception("Personal não Localizado");
            }
            _dbContext.Remove(personalDeletar);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
