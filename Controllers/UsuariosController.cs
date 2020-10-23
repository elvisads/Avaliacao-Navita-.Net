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
    public class UsuariosController : ControllerBase
    {

        private readonly NavitaContexto _contexto;

        public UsuariosController(NavitaContexto contexto)
        {
            _contexto = contexto;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Criar([FromBody] Usuario usuario)
        {
            var existeUsuarioComMesmoEmail = _contexto.Usuarios.Any(a => a.Email.ToLower() == usuario.Email.ToLower());
            if (existeUsuarioComMesmoEmail)
            {
                return new ObjectResult("Já existe um usuario com o mesmo email") { StatusCode = 412 };
            }
            else
            {
                _contexto.Usuarios.Add(usuario);
                _contexto.SaveChanges();
                return new ObjectResult(string.Empty) { StatusCode = 201 };
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            var usuarios = _contexto.Usuarios.AsNoTracking().ToList();
            return Ok(usuarios);
        }
    }
}