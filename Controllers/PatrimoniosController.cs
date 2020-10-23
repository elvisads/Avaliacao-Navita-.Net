using Microsoft.AspNetCore.Mvc;
using Navita.Avaliacao.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace Navita.Avaliacao.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PatrimoniosController : ControllerBase
    {

        private readonly NavitaContexto _contexto;

        public PatrimoniosController(NavitaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Patrimonio patrimonio)
        {

            _contexto.Patrimonios.Add(patrimonio);
            _contexto.SaveChanges();
            return new ObjectResult(string.Empty) { StatusCode = 201};
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            var patrimonios = _contexto.Patrimonios.AsNoTracking().ToList();
            return Ok(patrimonios);
        }
    }
}