using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Models;

namespace RegistroTecnico.DAL
{
    public class ContextoPrueba : DbContext
    {
        public ContextoPrueba(DbContextOptions<ContextoPrueba> options)
            : base(options)
        {
        }

        public DbSet<Tecnicos> Tecnicos { get; set; } = default;
        public DbSet<Clientes> Clientes { get; set; } = default;
    }
}
