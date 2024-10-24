using ApplicationCore.Commands;
using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using AutoMapper;
using Infraestructure.Persistence;
using MediatR;

namespace Infraestructure.EventHandlers.Estudiantes
{
    public class EstudiantesHandler : IRequestHandler<EstudianteCreateCommand, Response<int>>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEstudiantesServices _service;

        public EstudiantesHandler(ApplicationDbContext context, IMapper mapper, IEstudiantesServices service)
        {
            _context = context;
            _mapper = mapper;
            _service = service;
        }

        public async Task<Response<int>> Handle(EstudianteCreateCommand command, CancellationToken cancellationToken)
        {
            // Crear una nueva instancia de la entidad usando el comando
            var es = new Domain.Entities.Estudiantes
            {
                nombre = command.nombre,
                edad = command.edad,
                correo = command.correo
            };

            // Mapeo del comando a la entidad
            var estudiante = _mapper.Map<Domain.Entities.Estudiantes>(es);

            // Agregar el estudiante al contexto
            await _context.AddAsync(estudiante, cancellationToken);
            // Guardar cambios en el contexto
            await _context.SaveChangesAsync(cancellationToken);

            // Retornar respuesta
            return new Response<int>(estudiante.id, "Registro Exitoso");
        }
    }
}
