
using cNetMvc.Model;

namespace cNetMvc.Repository
{
    public interface IDestinoRepository
    {
        Task<IEnumerable<Destino>> GetDestinos();

        Task<Destino> GetDestinoBYId(int id);

        void AddDestino(Destino destino);

        void AtualizarDestino(Destino destino);

        void DeletarDestino(Destino destino);

        Task<bool> SaveChangesAsync();
        
    }
}