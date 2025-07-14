using GrenciadorTarefasAPI.Models.Enums;

namespace GrenciadorTarefasAPI.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataVencimento { get; set; }
        public StatusTarefa Status { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public int ProjetoId { get; set; }
        public Projeto Projeto { get; set; }
        public ICollection<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
