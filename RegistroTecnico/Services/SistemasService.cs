using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Models;
using RegistroTecnico.DAL;
using System.Linq.Expressions;

namespace RegistroTecnicos.Services
{
    public class SistemasService(IDbContextFactory<ContextoPrueba> DbFactory)
    {
       
        public async Task<bool> Guardar(Sistemas sistema)
        {
            if (!await Existe(sistema.SistemaId))
            {
                return await Insertar(sistema);
            }
            else
            {
                return await Modificar(sistema);
            }
        }
   
        public async Task<bool> Existe(int SistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas.AnyAsync(s => s.SistemaId == SistemaId);
        }
        
        private async Task<bool> Insertar(Sistemas sistema)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Sistemas.Add(sistema);
            return await contexto.SaveChangesAsync() > 0;
        }
        
        private async Task<bool> Modificar(Sistemas sistema)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Update(sistema);
            return await contexto.SaveChangesAsync() > 0;
        }
        
        public async Task<Sistemas?> Buscar(int SistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas.FirstOrDefaultAsync(s => s.SistemaId == SistemaId);
        }
        
        public async Task<bool> Eliminar(int SistemaId)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas.AsNoTracking().Where(s => s.SistemaId == SistemaId).ExecuteDeleteAsync() > 0;
        }
       
        public async Task<List<Sistemas>> Listar(Expression<Func<Sistemas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Sistemas.AsNoTracking().Where(criterio).ToListAsync();
        }

    }
}