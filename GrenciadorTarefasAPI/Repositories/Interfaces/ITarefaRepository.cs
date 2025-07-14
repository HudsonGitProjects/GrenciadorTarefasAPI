using GrenciadorTarefasAPI.Models;

namespace GrenciadorTarefasAPI.Repositories.Interfaces
{
    public interface ITarefaRepository
    {
        Task<IEnumerable<Tarefa>> ObterPorProjetoAsync(int projetoId);
        Task<Tarefa> ObterPorIdAsync(int id);
        Task<Tarefa> CriarTarefaAsync(Tarefa tarefa);
        Task<bool> AtualizarTarefaAsync(Tarefa tarefa);
        Task<bool> RemoverTarefaAsync(int id);
        Task<int> ContarPorProjetoAsync(int projetoId);
        Task AdicionarComentarioAsync(Comentario comentario);
        Task AdicionarHistoricoAsync(HistoricoTarefa historico);

    }
}
