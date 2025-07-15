using GrenciadorTarefasAPI.Data;
using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Repositories;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using Moq;
using Xunit;

namespace GrenciadorTarefasAPI.Tests
{
    public class RelatorioServiceTests
    {
        private readonly Mock<IRelatorioService> _mockService;
        private readonly RelatorioService _service;

        public RelatorioServiceTests()
        {
            _mockService = new Mock<IRelatorioService>();
            _service = new RelatorioService(new Mock<AppDbContext>().Object); 
        }

        [Fact]
        public async Task GerarRelatorio()
        {
            var mockData = new List<HistoricoTarefa> {
                    new HistoricoTarefa { TarefaId = 1, Tarefa = new Tarefa { Id = 5 } }
                };

            _mockService.Setup(r => r.ObterRelatorioDesempenhoAsync()).ReturnsAsync(mockData);

            var resultado = await _service.ObterMediaTarefasConcluidasAsync();

            Assert.Single(resultado.ToString());
        }
    }
}
