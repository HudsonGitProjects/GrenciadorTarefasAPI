using GrenciadorTarefasAPI.Models;

namespace GrenciadorTarefasAPI.Repositories.Interfaces
{
    public interface IProjetoRepository
    {
        Task<IEnumerable<Projeto>> ListarProjetosAsync();
        Task<Projeto?> ObterPorIdAsync(int id);
        Task<Projeto> CriarAsync(Projeto projeto);
        Task<bool> RemoverAsync(int id); // D
    }
}
