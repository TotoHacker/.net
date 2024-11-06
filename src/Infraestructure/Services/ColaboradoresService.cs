using ApplicationCore.Interfaces;
using ApplicationCore.Wrappers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ColaboradoresService : IColaboradoresService
    {
        private readonly DbContext _context; // Suponiendo que usas DbContext para interactuar con la base de datos

        public ColaboradoresService(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ColaboradorDto>> GetColaboradoresByFechaIngreso(DateTime fechaIngreso)
        {
            // Consulta a la base de datos para obtener los colaboradores con fecha de creación posterior a la fecha de ingreso
            var colaboradores = await _context.Set<ColaboradoresEntities>()
                .Where(c => c.FechaCreacion >= fechaIngreso)
                .Select(c => new ColaboradorDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Edad = c.Edad,
                    BirthDate = c.BirthDate,
                    IsProfesor = c.IsProfesor,
                    FechaCreacion = c.FechaCreacion
                })
                .ToListAsync();

            return colaboradores;
        }
    }
}
