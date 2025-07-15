using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrenciadorTarefasAPI.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly AppDbContext _context;

        public TarefaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tarefa>> ObterPorProjetoAsync(int projetoId)
        {
            return await _context.Tarefas
                .Include(t => t.Comentarios)
                .Where(t => t.ProjetoId == projetoId)
                .ToListAsync();
        }

        public async Task<Tarefa> ObterPorIdAsync(int id)
        {
            return await _context.Tarefas
                .Include(t => t.Comentarios)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tarefa> CriarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            await _context.SaveChangesAsync();
            return tarefa;
        }

        public async Task<bool> AtualizarAsync(Tarefa tarefa)
        {
            _context.Tarefas.Update(tarefa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoverTarefaAsync(int id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
                return false;

            _context.Tarefas.Remove(tarefa);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<int> ContarPorProjetoAsync(int projetoId)
        {
            return await _context.Tarefas.CountAsync(t => t.ProjetoId == projetoId);
        }

        public async Task AdicionarComentarioAsync(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
        }

        public async Task AdicionarHistoricoAsync(HistoricoTarefa historico)
        {
            _context.Historicos.Add(historico);
            await _context.SaveChangesAsync();
        }

        public Task<Tarefa> CriarTarefaAsync(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AtualizarTarefaAsync(Tarefa tarefa)
        {
            throw new NotImplementedException();
        }
    }
}
    
