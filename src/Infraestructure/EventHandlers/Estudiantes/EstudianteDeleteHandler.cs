using System.Threading;
using System.Threading.Tasks;
using ApplicationCore.Wrappers; 
using ApplicationCore.Commands; 
using AutoMapper;
using Infraestructure.Persistence; 
using MediatR;

namespace Infraestructure.EventHandlers.Estudiantes
{
    public class EstudianteDeleteHandler : IRequestHandler<EstudianteDeleteCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;

        public EstudianteDeleteHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<int>> Handle(EstudianteDeleteCommand command, CancellationToken cancellationToken)
        {
            // Buscar el estudiante por ID
            var estudiante = await _context.Estudiantes.FindAsync(command.id);
            if (estudiante == null)
            {
                return new Response<int>(0, "Estudiante no encontrado.");
            }

            // Eliminar el estudiante
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync(cancellationToken);

            // Retornar la respuesta
            return new Response<int>(estudiante.id, "Eliminación exitosa");
        }
    }

}
