using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Wrappers;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Domain.Entities;
using MediatR;
using ApplicationCore.Commands;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using System.Linq;

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
            _mediator = mediator;
        }

        /// <summary>
        /// Lista de Estudiantes - GET
        /// </summary>
        [HttpGet("getEstudiantes")]
        public async Task<IActionResult> GetEstudiantes()
        {
            var response = await _service.GetEstudiantes();
            return Ok(response);
        }

        [HttpPost("createEstudiantes")]
        public async Task<ActionResult<Response<int>>> CreateEstudiante(EstudianteCreateCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("deleteEstudiante/{id}")]
        public async Task<ActionResult<Response<int>>> DeleteEstudiante([FromRoute] int id)
        {
            var result = await _service.DeleteEstudiante(id);
            return Ok(result);
        }

        [HttpGet("createEstudiantesPdf")]
        public async Task<IActionResult> CreateEstudiantesPdf()
        {
            // Usa XFontStyleEx para obtener estilos de fuente
            XFont fontBold = new XFont("Verdana", 12, XFontStyleEx.Bold);
            XFont fontNormal = new XFont("Verdana", 12, XFontStyleEx.Regular); // Cambiado de Regular a Normal

            var estudiantesResponse = await _service.GetEstudiantes();
            if (estudiantesResponse == null || estudiantesResponse.Data == null || !estudiantesResponse.Data.Any())
                return NotFound("No se encontraron estudiantes.");

            // Crear un documento PDF
            using (var document = new PdfDocument())
            {
                document.Info.Title = "Lista de Estudiantes";

                // Crear una página
                var page = document.AddPage();
                page.Size = PdfSharp.PageSize.A4;
                page.Orientation = PdfSharp.PageOrientation.Portrait;

                // Crear un objeto XGraphics para dibujar en la página
                var gfx = XGraphics.FromPdfPage(page);

                // Dibuja el título
                gfx.DrawString("Lista de Estudiantes", fontBold, XBrushes.Black, 20, 40);

                // Dibuja encabezados de la tabla
                gfx.DrawString("ID", fontNormal, XBrushes.Black, 20, 80);
                gfx.DrawString("Nombre", fontNormal, XBrushes.Black, 100, 80);
                gfx.DrawString("Email", fontNormal, XBrushes.Black, 300, 80);

                int yPosition = 100;
                foreach (var estudiante in estudiantesResponse.Data)
                {
                    gfx.DrawString(estudiante.id.ToString(), fontNormal, XBrushes.Black, 20, yPosition);
                    gfx.DrawString(estudiante.nombre, fontNormal, XBrushes.Black, 100, yPosition);
                    gfx.DrawString(estudiante.correo, fontNormal, XBrushes.Black, 300, yPosition);
                    yPosition += 20; // Espacio entre filas
                }

                // Guardar el documento en un MemoryStream
                using (var stream = new MemoryStream())
                {
                    document.Save(stream, false);
                    stream.Position = 0; // Reiniciar el flujo para leerlo desde el principio
                    return File(stream.ToArray(), "application/pdf", "Estudiantes.pdf");
                }
            }
        }
    }
}
