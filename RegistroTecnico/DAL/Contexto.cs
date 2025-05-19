using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Models;

public class Contexto : DbContext
{
    public Contexto()
    {
    }

    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

    public virtual DbSet<Tecnicos> Tecnicos { get; set; }
}
