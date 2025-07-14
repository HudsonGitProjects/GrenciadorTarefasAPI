using GrenciadorTarefasAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrenciadorTarefasAPI.Controllers
{
    [ApiController]
    [Route("api/relatorios")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioService _relatorioService;

        public RelatorioController(IRelatorioService relatorioService)
        {
            _relatorioService = relatorioService;
        }

        // GET: /api/relatorios/desempenho
        [HttpGet("desempenho")]
        public async Task<ActionResult<double>> ObterMediaConclusao()
        {
            var media = await _relatorioService.ObterMediaTarefasConcluidasUltimos30DiasAsync();//resumir esse nome 
            return Ok(media);
        }
    }
}