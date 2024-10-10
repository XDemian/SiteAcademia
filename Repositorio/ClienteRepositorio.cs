using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SiteAcademia.Data;
using SiteAcademia.Models;
using SiteAcademia.Repositorio.Interfaces;

namespace SiteAcademia.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {

        private readonly SiteAcademiaDBContext _dbContext;


        public ClienteRepositorio(SiteAcademiaDBContext siteAcademiaDBContext)
        {
            _dbContext = siteAcademiaDBContext;
        }

        public async Task<ClienteModel> CadastraCliente(ClienteModel cliente)
        {
            await _dbContext.Clientes.AddAsync(cliente);
            await _dbContext.SaveChangesAsync();
            return cliente;
        }


        public async Task<ClienteModel> AtualizarCliente(ClienteModel cliente, int id)
        {
            ClienteModel clientePorId = await BuscarClientePorId(id);

            if (clientePorId == null) 
            {
                throw new Exception("Cliente nao Existe no banco de dados");
            }
            
            clientePorId.Nome = cliente.Nome;
            clientePorId.Senha = cliente.Senha;
            clientePorId.Altura = cliente.Altura;
            clientePorId.Email = cliente.Email;
            clientePorId.Peso = cliente.Peso;

            _dbContext.Clientes.Update(clientePorId);
            await _dbContext.SaveChangesAsync();

            return clientePorId;
        }

        public async Task<List<ClienteModel>> BuscarTodosCliente()
        
        
        {
            List<ClienteModel> clientes = await (_dbContext.Clientes.ToListAsync());

            if(clientes.Count == 0 || clientes == null)
            {
                throw new Exception("Sem CLientes cadastrados");
            }

            return clientes;
        }

        public async Task<ClienteModel> BuscarClientePorId(int id)
        {
            ClienteModel clienteLocalizado = await _dbContext.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (clienteLocalizado == null)
            {
                throw new Exception();
            }

            return clienteLocalizado;

        }
     
        public async Task<bool> DeletarCliente(int id)
        {
            ClienteModel clienteDeletar = await BuscarClientePorId(id);
            _dbContext.Clientes.Remove(clienteDeletar);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
