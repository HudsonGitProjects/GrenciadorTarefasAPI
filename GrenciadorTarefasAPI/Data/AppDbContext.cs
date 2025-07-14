using GrenciadorTarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GrenciadorTarefasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public DbSet<HistoricoTarefa> Historicos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) { 

       
            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Prioridade)
                .HasConversion<string>();

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Status)
                .HasConversion<string>();

            // Projeto -> Tarefas (1:N)
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tarefa -> Comentários (1:N)
            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Tarefa)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Tarefa -> Histórico (1:N)
            modelBuilder.Entity<HistoricoTarefa>()
                .HasOne(h => h.Tarefa)
                .WithMany() // se quiser histórico navegável da tarefa, troque por .WithMany(t => t.Historicos)
                .HasForeignKey(h => h.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Campos obrigatórios
            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Titulo)
                .IsRequired();

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Nome)
                .IsRequired();



        }
    }
}
