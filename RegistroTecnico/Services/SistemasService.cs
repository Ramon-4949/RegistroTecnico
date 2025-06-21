using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions; 

namespace RegistroTecnico.Services 
{
    public class SistemasService
    {
        private readonly IDbContextFactory<ContextoPrueba> _dbFactory; 

        public SistemasService(IDbContextFactory<ContextoPrueba> dbFactory) 
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Guardar(Sistemas sistema)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync(); 
            if (sistema.SistemaId == 0)
            {
                contexto.Sistemas.Add(sistema);
            }
            else
            {
                contexto.Entry(sistema).State = EntityState.Modified;
            }
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Sistemas?> Buscar(int id)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync(); 
            return await contexto.Sistemas.FindAsync(id);
        }

       
        public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync(); 
            return await contexto.Sistemas
                .AsNoTracking()
                .Where(criterio)
                .ToListAsync();
        }

        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Sistemas
                .Where(s => s.SistemaId == id)
                .ExecuteDeleteAsync() > 0;
        }
    }
}