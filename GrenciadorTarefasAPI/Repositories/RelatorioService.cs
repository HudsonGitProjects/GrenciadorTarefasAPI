using GrenciadorTarefasAPI.Data;
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

        public async Task<double> ObterMediaTarefasConcluidasUltimos30DiasAsync()
        {
            var dataLimite = DateTime.UtcNow.AddDays(-30);

            // Seleciona tarefas concluídas nos últimos 30 dias
            var tarefasConcluidas = await _context.Tarefas
                .Where(t => t.Status == StatusTarefa.Concluida && t.DataVencimento >= dataLimite)
                .ToListAsync();

            // Simulação: agrupando por projeto, pois não temos usuário autenticado
            var totalProjetos = await _context.Projetos.CountAsync();

            if (totalProjetos == 0) return 0;

            return (double)tarefasConcluidas.Count / totalProjetos;
        }
    }
}
