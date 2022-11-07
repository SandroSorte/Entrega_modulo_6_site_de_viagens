
using cNetMvc.Model;

namespace cNetMvc.Repository
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetClientes();

        Task<Cliente> GetClienteBYId(int id);

        void AddCliente(Cliente cliente);

        void AtualizarCliente(Cliente cliente);

        void DeletarCliente(Cliente cliente);

        Task<bool> SaveChangesAsync();
        
    }
}