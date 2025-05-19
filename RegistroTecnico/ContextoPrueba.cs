using Microsoft.EntityFrameworkCore;

namespace RegistroTecnico.DAL
{
    public class ContextoPrueba : DbContext
    {
        public ContextoPrueba(DbContextOptions<ContextoPrueba> options)
            : base(options)
        {
        }

        public DbSet<RegistroTecnico.Models.Tecnicos> Tecnicos { get; set; }
    }
}
