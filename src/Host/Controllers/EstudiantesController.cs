using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Wrappers;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Domain.Entities;
using MediatR;
using ApplicationCore.Commands;

namespace Host.Controllers
{
    [Route("api/estudiantes")]
    [ApiController]
    public class EstudiantesController : ControllerBase
    {
        private readonly IEstudiantesServices _service;
        private readonly IMediator _mediator;
        public EstudiantesController(IEstudiantesServices service, IMediator mediator)
        {
            _service = service;
            _mediator = mediator; // Ahora lo asignas correctamente
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
        [HttpPost("createEstudiantes")]
        public async Task<ActionResult<Response<int>>> CreateEstudiante(EstudianteCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

    }
}