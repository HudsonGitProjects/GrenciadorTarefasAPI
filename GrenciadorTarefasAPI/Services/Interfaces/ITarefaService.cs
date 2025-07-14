using GrenciadorTarefasAPI.Models;

namespace GrenciadorTarefasAPI.Services.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<Tarefa>> ListarPorProjetoAsync(int projetoId);
        Task<Tarefa?> BuscarPorIdAsync(int id);
        Task<Tarefa> CriarAsync(Tarefa tarefa);
        Task<Tarefa> AtualizarAsync(Tarefa tarefa, string usuario);
        Task<bool> RemoverTarefaAsync(int id);
        Task AdicionarComentarioTarefaAsync(int tarefaId, string conteudo);

    }
}
