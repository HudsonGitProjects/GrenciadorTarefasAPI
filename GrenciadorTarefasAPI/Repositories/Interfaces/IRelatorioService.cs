namespace GrenciadorTarefasAPI.Repositories.Interfaces
{
    public interface IRelatorioService
    {
        Task<double> ObterMediaTarefasConcluidasUltimos30DiasAsync();

    }
}
