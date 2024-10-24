using ApplicationCore.Interfaces;
using AutoMapper;
using Infraestructure.Persistence;
using System.Threading.Tasks;
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

        // Implementación del método DeleteEstudiante
        public async Task<Response<int>> DeleteEstudiante(int id)
        {
            // Buscar el estudiante por ID
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return new Response<int>(0, "Estudiante no encontrado.");
            }

            // Eliminar el estudiante
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            // Retornar la respuesta con el ID del estudiante eliminado
            return new Response<int>(estudiante.id, "Eliminación exitosa.");
        }
    }
}
