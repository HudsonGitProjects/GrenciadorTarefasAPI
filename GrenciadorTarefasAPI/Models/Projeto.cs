namespace GrenciadorTarefasAPI.Models
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}
