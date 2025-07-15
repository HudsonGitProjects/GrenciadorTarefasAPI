using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Repositories.Interfaces;
using GrenciadorTarefasAPI.Services;
using Moq;
using NuGet.ContentModel;
using Xunit;


namespace GrenciadorTarefasAPI.Tests
{
    public class ProjetoServiceTests
    {
        private readonly Mock<IProjetoRepository> _mockRepo;
        private readonly ProjetoService _service;

        public ProjetoServiceTests()
        {
            _mockRepo = new Mock<IProjetoRepository>();
            _service = new ProjetoService(_mockRepo.Object);
        }

        [Fact]
        public async Task CriarProjeto_DeveRetornarProjetoComNome()
        {
            var projeto = new Projeto { Nome = "Novo Projeto" };
            _mockRepo.Setup(r => r.CriarAsync(It.IsAny<Projeto>())).ReturnsAsync(projeto);

            var resultado = await _service.CriarAsync(projeto);

            Assert.Equal("Novo Projeto", resultado.Nome);
        }
    }
}
