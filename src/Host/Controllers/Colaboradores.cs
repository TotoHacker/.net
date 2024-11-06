using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Host.Controllers
{
    [Route("api/Colaborador")]
    [ApiController]
    public class ColaboradoresController : ControllerBase
    {
        private readonly IColaboradoresService _service;

        public ColaboradoresController(IColaboradoresService service)
        {
            _service = service;
        }

        // Método GET para obtener colaboradores filtrados por fecha de ingreso
        [HttpGet("getColaboradoresByFechaIngreso")]
        public async Task<IActionResult> GetColaboradoresByFechaIngreso([FromQuery] DateTime fechaIngreso)
        {
            // Llamada al servicio para obtener los colaboradores
            var colaboradores = await _service.GetColaboradoresByFechaIngreso(fechaIngreso);

            // Si no se encontraron colaboradores, retornamos un 404
            if (colaboradores == null || !colaboradores.Any())
            {
                return NotFound("No se encontraron colaboradores."); // Retorna un 404 con un mensaje
            }

            // Si se encuentran colaboradores, retornamos los datos
            return Ok(colaboradores); // Retorna los datos en formato OK
        }
    }
}
