using Microsoft.AspNetCore.Mvc;
using Navita.Avaliacao.Modelos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Navita.Avaliacao.Controllers
{
    [Authorize] 
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MarcasController : ControllerBase
    {
        private readonly NavitaContexto _contexto;

        public MarcasController(NavitaContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Marca marca)
        {
            try
            {
                var existeMarcaComMesmoNome = _contexto.Marcas.Any(a => a.Nome.ToLower() == marca.Nome.ToLower());
                if (existeMarcaComMesmoNome)
                {
                    return new ObjectResult("Já existe uma marca com mesmo nome") { StatusCode = 412 };
                }
                else
                {
                    _contexto.Marcas.Add(marca);
                    _contexto.SaveChanges();
                    return new ObjectResult(string.Empty) { StatusCode = 201 };
                }
            }
            catch (Exception exception)
            {
                return new ObjectResult(exception.Message) { StatusCode = 500 };
            }
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                var marcas = _contexto.Marcas.AsNoTracking().ToList();
                return Ok(marcas);
            }
            catch (Exception exception)
            {
                return new ObjectResult(exception.Message) { StatusCode = 500 };
            }
        }

        [HttpPut]
        public IActionResult AlterarMarca([FromBody] Marca marca)
        {
            try
            {
                var altMarca = _contexto.Marcas.FirstOrDefault(f => f.MarcaId == marca.MarcaId);
                if (altMarca == null)
                {
                    return new ObjectResult("Marca inexistente") { StatusCode = 412 };
                }
                else
                {
                    var existeMarcaComMesmoNome = _contexto.Marcas.Any(a => a.Nome.ToLower() == marca.Nome.ToLower());
                    if (existeMarcaComMesmoNome)
                    {
                        return new ObjectResult("Já existe uma marca com mesmo nome") { StatusCode = 412 };
                    }
                    else
                    {
                        _contexto.Marcas.Update(marca);
                        _contexto.SaveChanges();
                        return Ok();
                    }
                }
            }
            catch (Exception exception)
            {
                return new ObjectResult(exception.Message) { StatusCode = 500 };
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarMarca(int id)
        {
            try
            {
                var marca = _contexto.Marcas.FirstOrDefault(f => f.MarcaId == id);
                if (marca == null)
                {
                    return new ObjectResult("Marca inexistente") { StatusCode = 412 };
                }
                else
                {
                    var existePatrimonio = _contexto.Patrimonios.AsNoTracking().Any(a => a.MarcaId == id);
                    if (existePatrimonio)
                    {
                        return new ObjectResult($"O id {id} não pode ser deletado, pois esté vinculado a um patrimônio")
                        { StatusCode = 412 };
                    }
                    else
                    {
                        _contexto.Marcas.Remove(marca);
                        _contexto.SaveChanges();
                        return new ObjectResult(string.Empty) { StatusCode = 410 }; // 410 deletado com sucesso
                    }
                }
            }
            catch (Exception exception)
            {
                return new ObjectResult(exception.Message) { StatusCode = 500 };
            }
        }
    }
}