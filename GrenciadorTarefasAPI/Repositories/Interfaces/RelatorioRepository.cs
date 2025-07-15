using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using System.Data.Entity;

namespace GrenciadorTarefasAPI.Repositories.Interfaces
{
    public class RelatorioRepository : IRelatorioService
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<double> ObterMediaTarefasConcluidasAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<HistoricoTarefa>> ObterRelatorioDesempenhoAsync()
        {
            return await _context.Historicos
                .OrderByDescending(h => h.Modificacao)
                .ToListAsync();
        }
    }
}
