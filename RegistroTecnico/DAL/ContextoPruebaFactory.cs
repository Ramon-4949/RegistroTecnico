using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace RegistroTecnico.DAL
{
    public class ContextoPruebaFactory : IDesignTimeDbContextFactory<ContextoPrueba>
    {
        public ContextoPrueba CreateDbContext(String[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoPrueba>();

            optionsBuilder.UseSqlServer("Server=RegistroTecnico.mssql.somee.com;Database=RegistroTecnico;User Id=Ramon-49_SQLLogin_1;Password=q4gnichdnp;Persist Security Info=False;TrustServerCertificate=True");

            return new ContextoPrueba(optionsBuilder.Options);
        }
        
    }
}
