using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Models.Enums;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrenciadorTarefasAPI.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly AppDbContext _context;

        public ProjetoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Projeto>> ListarProjetosAsync()
        {
            return await _context.Projetos
                .Include(p => p.Tarefas)
                .ToListAsync();
        }

        public async Task<Projeto?> ObterPorIdAsync(int id)
        {
            return await _context.Projetos
                .Include(p => p.Tarefas)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projeto> CriarAsync(Projeto projeto)
        {
            _context.Projetos.Add(projeto);
            await _context.SaveChangesAsync();
            return projeto;
        }

        public async Task<bool> RemoverAsync(int id)
        {
            var projeto = await _context.Projetos
                .Include(p => p.Tarefas)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (projeto == null)
                return false;

            bool possuiPendentes = projeto.Tarefas.Any(t => t.Status == StatusTarefa.Pendente);
            if (possuiPendentes)
                return false;

            _context.Projetos.Remove(projeto);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

