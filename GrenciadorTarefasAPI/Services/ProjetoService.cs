using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using GrenciadorTarefasAPI.Services.Interfaces;

namespace GrenciadorTarefasAPI.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IProjetoRepository _projetoRepository;

        public ProjetoService(IProjetoRepository projetoRepository)
        {
            _projetoRepository = projetoRepository;
        }

        public Task<IEnumerable<Projeto>> ListarProjetosAsync() => _projetoRepository.ListarProjetosAsync();

        public Task<Projeto?> BuscarPorIdAsync(int id) => _projetoRepository.ObterPorIdAsync(id);

        public Task<Projeto> CriarAsync(Projeto projeto) => _projetoRepository.CriarAsync(projeto);

        public Task<bool> RemoverAsync(int id) => _projetoRepository.RemoverAsync(id);


    }
}
