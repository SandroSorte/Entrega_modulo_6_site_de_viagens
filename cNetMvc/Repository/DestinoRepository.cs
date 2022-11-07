
using cNetMvc.Database;
using cNetMvc.Model;
using Microsoft.EntityFrameworkCore;

namespace cNetMvc.Repository
{
    public class DestinoRepository : IDestinoRepository
 {

     private readonly ClienteDbContext _context;

     public DestinoRepository(ClienteDbContext context){
        _context = context;
     }


  public void AddDestino(Destino destino)
  {
   _context.Add(destino);
  }

  public void AtualizarDestino(Destino destino)
  {
   _context.Update(destino);
  }

  public void DeletarDestino(Destino destino)
  {
   _context.Remove(destino);
  }

  public async Task<Destino> GetDestinoBYId(int id)
  {
   return await _context.Destinos
   .Where(x => x.id == id).FirstOrDefaultAsync();
  }

  public async Task<IEnumerable<Destino>> GetDestinos()
  {
   return await _context.Destinos.ToListAsync();
  }
  public async Task<bool> SaveChangesAsync()
  {
       return await _context.SaveChangesAsync() > 0;
  }
}
}