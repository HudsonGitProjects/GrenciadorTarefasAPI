using System.ComponentModel.DataAnnotations;

namespace GrenciadorTarefasAPI.Models
{
    public class Comentario
    {
        [Key]
        public int TarefaId { get; internal set; }
        public string Conteudo { get; internal set; }

        public Tarefa Tarefa { get; set; }

    }
}
