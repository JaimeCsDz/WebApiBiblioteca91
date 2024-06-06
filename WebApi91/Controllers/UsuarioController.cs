using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        public readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _usuarioService.ObtenerUsuarios();
            return Ok(result);
        }

        [HttpGet("int:id")]
        public async Task<IActionResult> ObtenerUsuario(int id)
        {
            var result = await _usuarioService.ObtenerUsuario(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] UsuarioResponse request)
        {
            var result = await _usuarioService.CrearUsuario(request);
            return Ok(result);
        }

        [HttpDelete("deleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _usuarioService.DeleteUser(id);
            return Ok(result);
        }
        [HttpPut("updateUser/{id}")]
        public async Task<IActionResult>UpdateUser(int id, [FromBody] UsuarioResponse request)
        {
            var result = await _usuarioService.UpdateUsuario(id, request);
            return Ok(result);
        }

    }
}
