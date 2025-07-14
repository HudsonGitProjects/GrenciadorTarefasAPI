using System.ComponentModel.DataAnnotations;

namespace GrenciadorTarefasAPI.Models
{
    public class HistoricoTarefa
    {
        [Key]
        public int TarefaId { get; internal set; }
        public string Modificacao { get; internal set; }
        public string Usuario { get; internal set; }
        public Tarefa Tarefa { get; set; }

    }
}
