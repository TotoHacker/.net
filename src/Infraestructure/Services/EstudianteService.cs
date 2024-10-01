using ApplicationCore.Interfaces;
using AutoMapper;
using Infraestructure.Persistence;
using System.Threading.Tasks;
using Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Wrappers; // Asegúrate de que este espacio de nombres coincida con el de tu clase Response


namespace Infraestructure.Services
{
    public class EstudianteService : IEstudiantesServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EstudianteService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }

        public async Task<Response<object>> GetEstudiantes()
        {
            var list = await _context.Estudiantes.ToListAsync();
            return new Response<object> { Data = list };
        }
    }
}