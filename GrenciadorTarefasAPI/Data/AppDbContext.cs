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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Prioridade)
                .HasConversion<string>();

            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Projeto)
                .WithMany(p => p.Tarefas)
                .HasForeignKey(t => t.ProjetoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comentario>()
                .HasOne(c => c.Tarefa)
                .WithMany(t => t.Comentarios)
                .HasForeignKey(c => c.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HistoricoTarefa>()
                .HasOne(h => h.Tarefa)
                .WithMany() 
                .HasForeignKey(h => h.TarefaId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Tarefa>()
                .Property(t => t.Titulo)
                .IsRequired();

            modelBuilder.Entity<Projeto>()
                .Property(p => p.Nome)
                .IsRequired();
        }

           public async Task<List<HistoricoTarefa>> ObterRelatorioDesempenhoAsync()
            {
                return await Historicos.ToListAsync();
            }


        }
    }

