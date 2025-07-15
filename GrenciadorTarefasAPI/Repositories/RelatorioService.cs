using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Models.Enums;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrenciadorTarefasAPI.Repositories
{
    public class RelatorioService : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<double> ObterMediaTarefasConcluidasAsync()
        {
            var dataLimite = DateTime.UtcNow.AddDays(-30);

            var tarefasConcluidas = await _context.Tarefas
                .Where(t => t.Status == StatusTarefa.Concluida && t.DataVencimento >= dataLimite)
                .ToListAsync();

            var totalProjetos = await _context.Projetos.CountAsync();

            if (totalProjetos == 0) return 0;

            return (double)tarefasConcluidas.Count / totalProjetos;
        }
        public async Task<List<HistoricoTarefa>> ObterRelatorioDesempenhoAsync()
        {
            return await _context.ObterRelatorioDesempenhoAsync();
        }
    }
}
