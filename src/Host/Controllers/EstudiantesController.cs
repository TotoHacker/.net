using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;

namespace Host.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesServices _service;

        public EstudiantesController(IEstudiantesServices service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista de Estudiantes - GET
        /// </summary>
        [HttpGet("getEstudiantes")]
        public async Task<IActionResult> GetEstudiantes()
        {
            var response = await _service.GetEstudiantes(); // Llama al servicio para obtener la lista de estudiantes
            return Ok(response); // Devuelve un resultado 200 OK con la lista de estudiantes
        }
    }
}