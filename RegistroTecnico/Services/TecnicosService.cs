using Microsoft.EntityFrameworkCore;
using RegistroTecnico.DAL;
using RegistroTecnico.Models;
using System.Linq.Expressions;


namespace RegistroTecnico.Services;

public class TecnicosService
{
    private readonly ContextoPrueba _contexto;

    public TecnicosService(ContextoPrueba contexto)
    {
        _contexto = contexto;
    }

    public async Task<List<Tecnicos>> Listar(Expression<Func<Tecnicos, bool>> criterio)
    {
        return await _contexto.Tecnicos.Where(criterio).ToListAsync();
    }

    public async Task<Tecnicos?> Buscar(int id)
    {
        return await _contexto.Tecnicos.FindAsync(id);
    }

    public async Task<bool> Guardar(Tecnicos tecnico)
    {
        if (tecnico.TecnicoId == 0)
        {
            _contexto.Tecnicos.Add(tecnico);
        }
        else
        {
            _contexto.Entry(tecnico).State = EntityState.Modified;
        }

        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(Tecnicos tecnico)
    {
        _contexto.Tecnicos.Remove(tecnico);
        return await _contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> ExisteNombre(string nombre)
    {
        return await _contexto.Tecnicos.AnyAsync(t => t.Nombres.ToLower() == nombre.ToLower());
    }
}
