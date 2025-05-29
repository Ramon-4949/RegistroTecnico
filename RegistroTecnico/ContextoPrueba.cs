using Microsoft.AspNetCore.Authentication;
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
        public DbSet<Tickets> Tickets { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.Cliente)
                .WithMany()
                .HasForeignKey(t => t.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tickets>()
                .HasOne(t => t.Tecnico)
                .WithMany()
                .HasForeignKey(t => t.TecnicoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
