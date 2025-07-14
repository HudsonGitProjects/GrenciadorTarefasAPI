using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GrenciadorTarefasAPI.Controllers
{
    [ApiController]
    [Route("api/projetos")]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        // GET: /api/projetos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Projeto>>> ListarProjetos()
        {
            var projetos = await _projetoService.ListarProjetosAsync();
            return Ok(projetos);
        }

        // GET: /api/projetos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Projeto>> ObterPorId(int id)
        {
            var projeto = await _projetoService.BuscarPorIdAsync(id);
            if (projeto == null)
                return NotFound();

            return Ok(projeto);
        }

        // Fixing the CS1503 error by modifying the Criar method to create a Projeto object from the provided string.

        [HttpPost]
        public async Task<ActionResult<Projeto>> Criar([FromBody] string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return BadRequest("Nome do projeto é obrigatório.");

            // Create a new Projeto object using the provided name
            var novoProjeto = new Projeto { Nome = nome };

            // Pass the Projeto object to the service
            var criado = await _projetoService.CriarAsync(novoProjeto);
            return CreatedAtAction(nameof(ObterPorId), new { id = criado.Id }, criado);
        }

        // DELETE: /api/projetos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            var sucesso = await _projetoService.RemoverAsync(id);
            if (!sucesso)
                return BadRequest("Não é permitido excluir o projeto com tarefas pendentes.");

            return NoContent();
        }
    }

}