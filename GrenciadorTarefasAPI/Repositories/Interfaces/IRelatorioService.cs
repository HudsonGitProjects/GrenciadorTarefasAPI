using GrenciadorTarefasAPI.Models;

namespace GrenciadorTarefasAPI.Repositories.Interfaces
{
    public interface IRelatorioService
    {
        Task<double> ObterMediaTarefasConcluidasAsync();
        Task<List<HistoricoTarefa>> ObterRelatorioDesempenhoAsync();


    }
}
