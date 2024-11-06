using System;

namespace Domain.Entities
{
    public class ColaboradoresEntities // Cambia 'class' a 'public class'
    {
        public int Id { get; set; }               // Identificador único
        public string Nombre { get; set; }        // Nombre del colaborador
        public int Edad { get; set; }             // Edad del colaborador
        public DateTime BirthDate { get; set; }   // Fecha de nacimiento
        public bool IsProfesor { get; set; }      // Indica si el colaborador es profesor
        public DateTime FechaCreacion { get; set; } // Fecha de creación del registro
    }
}
