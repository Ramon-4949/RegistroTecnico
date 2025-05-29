using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;

namespace RegistroTecnico.Services
{
    public class TicketsService
    {
        private readonly IDbContextFactory<ContextoPrueba> _dbFactory;

        public TicketsService(IDbContextFactory<ContextoPrueba> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<bool> Guardar(Tickets ticket)
        {
            if (!await Existe(ticket.TicketId))
                return await Insertar(ticket);
            else
                return await Modificar(ticket);
        }

        public async Task<bool> Existe(int ticketId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Tickets.AnyAsync(t => t.TicketId == ticketId);
        }

        private async Task<bool> Insertar(Tickets ticket)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Tickets.Add(ticket);
            return await contexto.SaveChangesAsync() > 0;
        }

        private async Task<bool> Modificar(Tickets ticket)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            contexto.Update(ticket);
            return await contexto.SaveChangesAsync() > 0;
        }

        public async Task<Tickets?> Buscar(int ticketId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .Include(t => t.Cliente)
                .Include(t => t.Tecnico)
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        public async Task<bool> Eliminar(int ticketId)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .Where(t => t.TicketId == ticketId)
                .ExecuteDeleteAsync() > 0;
        }

        public async Task<List<Tickets>> Listar(Expression<Func<Tickets, bool>> criterio)
        {
            await using var contexto = await _dbFactory.CreateDbContextAsync();
            return await contexto.Tickets
                .Where(criterio)
                .Include(t => t.Cliente)
                .Include(t => t.Tecnico)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
