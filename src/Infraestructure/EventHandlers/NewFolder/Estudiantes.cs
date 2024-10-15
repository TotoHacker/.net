using ApplicationCore.Commands;
using ApplicationCore.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infraestructure.EventHandlers
{
    public class EstudiantesHandler : IRequestHandler<EstudianteCreateCommand, Response<int>>
    {
        private readonly IMapper _mapper;

        public EstudiantesHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(EstudianteCreateCommand request, CancellationToken cancellationToken)
        {
            // Aquí usas AutoMapper para mapear del comando a la entidad
            var estudiante = _mapper.Map<Estudiantes>(request);

            // Simulación de almacenamiento de datos (en lugar de un repositorio)
            // Aquí podrías, por ejemplo, devolver un ID generado.
            estudiante.id = new Random().Next(1, 1000);  // Simulación de ID autogenerado

            return new Response<int>(estudiante.id);
        }
    }
}
