
using cNetMvc.Database;
using cNetMvc.Model;
using Microsoft.EntityFrameworkCore;

namespace cNetMvc.Repository
{
 public class ClienteRepository : IClienteRepository
 {

     private readonly ClienteDbContext _context;

     public ClienteRepository(ClienteDbContext context){
        _context = context;
     }


  public void AddCliente(Cliente cliente)
  {
   _context.Add(cliente);
  }

  public void AtualizarCliente(Cliente cliente)
  {
   _context.Update(cliente);
  }

  public void DeletarCliente(Cliente cliente)
  {
   _context.Remove(cliente);
  }

  public async Task<Cliente> GetClienteBYId(int id)
  {
   return await _context.Clientes
   .Where(x => x.id == id).FirstOrDefaultAsync();
  }

  public async Task<IEnumerable<Cliente>> GetClientes()
  {
   return await _context.Clientes.ToListAsync();
  }
  public async Task<bool> SaveChangesAsync()
  {
       return await _context.SaveChangesAsync() > 0;
  }
 }
}