using Microsoft.EntityFrameworkCore;
using RegistroTecnico.Models;
using RegistroTecnico.DAL;
using System.Linq.Expressions; 

namespace RegistroTecnico.Services 
{
    public class ClientesService
    {
        private readonly IDbContextFactory<ContextoPrueba> _dbFactory;

        public ClientesService(IDbContextFactory<ContextoPrueba> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Guardar(Clientes cliente)
        {
            if (!await Existe(cliente.ClienteId))
                return await Insertar(cliente);
            else
                return await Modificar(cliente);
        }

        public async Task<bool> Existe(int clienteId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes.AnyAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> ExisteNombre(string nombres, int? clienteId = null)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AnyAsync(c => c.Nombres.ToLower() == nombres.ToLower()
                                && (clienteId == null || c.ClienteId != clienteId));
        }

        public async Task<bool> ExisteRnc(string rnc, int? clienteId = null)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .AnyAsync(c => c.Rnc.ToLower() == rnc.ToLower()
                                && (clienteId == null || c.ClienteId != clienteId));
        }

        private async Task<bool> Insertar(Clientes cliente)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Clientes.Add(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Clientes cliente)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(cliente);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Clientes?> Buscar(int clienteId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes.FirstOrDefaultAsync(c => c.ClienteId == clienteId);
        }

        public async Task<bool> Eliminar(int clienteId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(c => c.ClienteId == clienteId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Clientes>> Listar(Expression<Func<Clientes, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Clientes
                .Where(criterio)
                .Include(c => c.Tecnico) 
                .AsNoTracking()
                .ToListAsync();
        }
    }
}