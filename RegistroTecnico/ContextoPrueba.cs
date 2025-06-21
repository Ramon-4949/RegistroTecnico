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

        public DbSet<Tecnicos> Tecnicos { get; set; } = default!;
        public DbSet<Clientes> Clientes { get; set; } = default!;
        public DbSet<Tickets> Tickets { get; set; } = default!;
        public DbSet<Sistemas> Sistemas { get; set; } = default!;

        public DbSet<Ventas> Ventas { get; set; } = default!;
        public DbSet<VentasDetalle> VentasDetalle { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<VentasDetalle>()
                .HasOne(vd => vd.Sistema)
                .WithMany()
                .HasForeignKey(vd => vd.SistemaId)
                .OnDelete(DeleteBehavior.Restrict);

           
            modelBuilder.Entity<Ventas>()
                .HasOne(v => v.Cliente)
                .WithMany(c => c.Ventas) 
                .HasForeignKey(v => v.ClienteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}