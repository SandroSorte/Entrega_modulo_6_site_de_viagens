
using cNetMvc.Model;
using Microsoft.EntityFrameworkCore;

namespace cNetMvc.Database
{
    public class ClienteDbContext : DbContext
    {
        public ClienteDbContext(DbContextOptions<ClienteDbContext> options) : base(options){
        }

        public DbSet<Cliente> Clientes {set; get;}

        public DbSet<Destino> Destinos {set ;get ;}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            var cliente = modelBuilder.Entity<Cliente>();
            cliente.ToTable("cliente");
            cliente.HasKey(x => x.id);
            cliente.Property(x => x.id).HasColumnName("Id").ValueGeneratedOnAdd();
            cliente.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            cliente.Property(x => x.dataNascimento).HasColumnName("data_nascimento");

        }
    }
}