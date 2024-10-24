using ApplicationCore.Commands;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    public class EstudiantesProfile : Profile // Cambié el nombre de la clase
    {
        public EstudiantesProfile()
        {
            CreateMap<EstudianteCreateCommand, Estudiantes>()
                .ForMember(x => x.id, y => y.Ignore()); 
        }
    }
}
