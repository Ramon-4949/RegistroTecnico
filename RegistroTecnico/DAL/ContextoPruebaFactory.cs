using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace RegistroTecnico.DAL
{
    public class ContextoPruebaFactory : IDesignTimeDbContextFactory<ContextoPrueba>
    {
        public ContextoPrueba CreateDbContext(String[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextoPrueba>();

            optionsBuilder.UseSqlServer("Server=RegistroTecnicos.mssql.somee.com;packet size=4096;user id=Ramon-49_SQLLogin_1;pwd=q4gnichdnp;data source=RegistroTecnicos.mssql.somee.com;persist security info=False;initial catalog=RegistroTecnicos;TrustServerCertificate=True;");

            return new ContextoPrueba(optionsBuilder.Options);
        }
        
    }
}
