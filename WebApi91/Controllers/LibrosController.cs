using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosService _librosService;
        public LibrosController(ILibrosService librosService)
        {
           _librosService = librosService;
        }
        [HttpGet]
        public async Task<IActionResult> GetLibros()
        {
            var result = await _librosService.GetLibros();
            return Ok(result);
        }
    }
}
