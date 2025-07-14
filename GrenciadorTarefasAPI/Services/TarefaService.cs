using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using GrenciadorTarefasAPI.Services.Interfaces;

namespace GrenciadorTarefasAPI.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly AppDbContext _context;

        public TarefaService(ITarefaRepository tarefaRepository, AppDbContext context)
        {
            _tarefaRepository = tarefaRepository;
            _context = context;
        }

        public Task<IEnumerable<Tarefa>> ListarPorProjetoAsync(int projetoId)
            => _tarefaRepository.ObterPorProjetoAsync(projetoId);

        public Task<Tarefa?> BuscarPorIdAsync(int id)
            => _tarefaRepository.ObterPorIdAsync(id);

        public async Task<Tarefa> CriarAsync(Tarefa tarefa)
        {
            int count = await _tarefaRepository.ContarPorProjetoAsync(tarefa.ProjetoId);
            if (count >= 20)
                throw new InvalidOperationException("O projeto já possui o limite máximo de 20 tarefas.");

            return await _tarefaRepository.CriarTarefaAsync(tarefa);
        }

        public async Task<Tarefa> AtualizarAsync(Tarefa tarefa, string usuario)
        {
            var original = await _tarefaRepository.ObterPorIdAsync(tarefa.Id);
            if (original == null) throw new KeyNotFoundException("Tarefa não encontrada.");

            if (original.Prioridade != tarefa.Prioridade)
                throw new InvalidOperationException("A prioridade da tarefa não pode ser alterada.");

            var alteracoes = new List<string>();
            if (original.Status != tarefa.Status)
                alteracoes.Add($"Status: {original.Status} -> {tarefa.Status}");
            if (original.Titulo != tarefa.Titulo)
                alteracoes.Add($"Título: {original.Titulo} -> {tarefa.Titulo}");
            if (original.Descricao != tarefa.Descricao)
                alteracoes.Add($"Descrição modificada");

            if (alteracoes.Any())
            {
                _context.Historicos.Add(new HistoricoTarefa
                {
                    TarefaId = tarefa.Id,
                    Modificacao = string.Join(" | ", alteracoes),
                    Usuario = usuario
                });
                await _context.SaveChangesAsync();
            }

            var atualizado = await _tarefaRepository.AtualizarTarefaAsync(tarefa);
            if (!atualizado) throw new InvalidOperationException("Falha ao atualizar a tarefa.");

            return tarefa;
        }

        public Task<bool> RemoverTarefaAsync(int id)
            => _tarefaRepository.RemoverTarefaAsync(id);

        public async Task AdicionarComentarioTarefaAsync(int tarefaId, string conteudo)
        {
            var tarefa = await _tarefaRepository.ObterPorIdAsync(tarefaId);
            if (tarefa == null) throw new KeyNotFoundException("Tarefa não encontrada.");

            var comentario = new Comentario
            {
                TarefaId = tarefaId,
                Conteudo = conteudo
            };
            _context.Comentarios.Add(comentario);

            _context.Historicos.Add(new HistoricoTarefa
            {
                TarefaId = tarefaId,
                Modificacao = $"Comentário adicionado: {conteudo}",
                Usuario = "Sistema"
            });

            await _context.SaveChangesAsync();
        }
    }
}