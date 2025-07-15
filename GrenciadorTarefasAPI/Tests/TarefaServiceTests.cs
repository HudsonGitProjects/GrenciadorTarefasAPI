using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using GrenciadorTarefasAPI.Services;
using Moq;
using Xunit;

namespace GrenciadorTarefasAPI.Tests
{
    public class TarefaServiceTests
    {
        private readonly Mock<ITarefaRepository> _mockRepo;
        private readonly Mock<AppDbContext> _mockContext;
        private readonly TarefaService _service;

        public TarefaServiceTests()
        {
            _mockRepo = new Mock<ITarefaRepository>();
            _mockContext = new Mock<AppDbContext>();
            _service = new TarefaService(_mockRepo.Object, _mockContext.Object);
        }

        [Fact]
        public async Task AdicionarTarefa_DeveRetornarTarefaComTitulo()
        {
            var tarefa = new Tarefa { Titulo = "Teste", ProjetoId = 1 };
            _mockRepo.Setup(r => r.CriarTarefaAsync(It.IsAny<Tarefa>())).ReturnsAsync(tarefa);

            var resultado = await _service.CriarAsync(tarefa);

            Assert.Equal("Teste", resultado.Titulo);
        }
    }
}
