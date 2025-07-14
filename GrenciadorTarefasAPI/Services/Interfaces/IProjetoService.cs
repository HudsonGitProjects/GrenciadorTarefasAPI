using GrenciadorTarefasAPI.Models;

namespace GrenciadorTarefasAPI.Services.Interfaces
{
    public interface IProjetoService
    {
        Task<IEnumerable<Projeto>> ListarProjetosAsync();
        Task<Projeto?> BuscarPorIdAsync(int id);
        Task<Projeto> CriarAsync(Projeto projeto);
        Task<bool> RemoverAsync(int id);
    }
}
