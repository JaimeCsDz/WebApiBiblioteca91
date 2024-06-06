using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutoreService _autoreService;
        public AutoresController(IAutoreService autoreService) 
        { 
            _autoreService = autoreService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAutores() 
        {
            var result = await _autoreService.GetAutores();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] Autor request)
        {
            var result = await _autoreService.Crear(request);
            return Ok(result);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> ActualizarAutor(int id, [FromBody] Autor request)
        {
            var result = await _autoreService.Actualizar(id, request);
            return Ok(result);
        }
        [HttpDelete]
        public async Task<IActionResult>EliminarAutor(int PkAutor)
        {
            var result = await _autoreService.Eliminar(PkAutor);
            return Ok(result);
        }

    }
}
