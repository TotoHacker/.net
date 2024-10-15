using ApplicationCore.Commands;
using ApplicationCore.DTOs;
using AutoMapper;
using Domain.Entities;

namespace ApplicationCore.Mappings
{
    class Estudiantess : Profile
    {
        public Estudiantess() {
            CreateMap<EstudianteCreateCommand, Estudiantes>()
                .ForMember(x => x.id , y => y.Ignore());
        }
    }
}
