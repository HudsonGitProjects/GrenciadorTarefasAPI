using GrenciadorTarefasAPI.Models;
using GrenciadorTarefasAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrenciadorTarefasAPI.Controllers
{
  
        [ApiController]
        [Route("api/tarefas")]
        public class TarefaController : ControllerBase
        {
            private readonly ITarefaService _tarefaService;

            public TarefaController(ITarefaService tarefaService)
            {
                _tarefaService = tarefaService;
            }

            // GET: /api/tarefas/projeto/{projetoId}
            [HttpGet("projeto/{projetoId}")]
            public async Task<ActionResult<IEnumerable<Tarefa>>> ListarTarefasDoProjeto(int projetoId)
            {
                var tarefas = await _tarefaService.ListarPorProjetoAsync(projetoId);
                return Ok(tarefas);
            }

            // POST: /api/tarefas/projeto/{projetoId}
            [HttpPost("projeto/{projetoId}")]
            public async Task<ActionResult<Tarefa>> CriarTarefa(int projetoId, [FromBody] Tarefa tarefa)
            {
                if (tarefa == null)
                    return BadRequest("Dados da tarefa são obrigatórios.");

                tarefa.ProjetoId = projetoId;

                var criada = await _tarefaService.CriarAsync(tarefa);
                return CreatedAtAction(nameof(ListarTarefasDoProjeto), new { projetoId }, criada);
            }

            // PUT: /api/tarefas/{id}
            [HttpPut("{id}")]
            public async Task<IActionResult> Atualizar(int id, [FromBody] Tarefa tarefa)
            {
                if (tarefa == null)
                    return BadRequest("Tarefa inválida.");

                var atualizada = await _tarefaService.AtualizarAsync(tarefa, "mock-usuario"); 
                if (atualizada == null) 
                    return NotFound("Tarefa não encontrada ou prioridade inválida.");

                return NoContent();
            }

            // DELETE: /api/tarefas/{id}
            [HttpDelete("{id}")]
            public async Task<IActionResult> Remover(int id)
            {
                var removida = await _tarefaService.RemoverTarefaAsync(id);
                if (!removida)
                    return NotFound("Tarefa não encontrada.");

                return NoContent();
            }

            // POST: /api/tarefas/{id}/comentarios
            [HttpPost("{id}/comentarios")]
            public async Task<IActionResult> AdicionarComentario(int id, [FromBody] string comentario)
            {
                if (string.IsNullOrWhiteSpace(comentario))
                    return BadRequest("Comentário é obrigatório.");

                await _tarefaService.AdicionarComentarioTarefaAsync(id, comentario);//Mock usuario
                return Ok("Comentário adicionado com sucesso.");
            }
        }
    }
