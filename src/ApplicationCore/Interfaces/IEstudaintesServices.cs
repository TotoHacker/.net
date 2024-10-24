    
using ApplicationCore.Wrappers; // Asegúrate de que este espacio de nombres coincida con el de tu clase Response

namespace ApplicationCore.Interfaces
{
    public interface IEstudiantesServices
    {
        Task<Response<object>> GetEstudiantes();
        Task<Response<int>> DeleteEstudiante(int id);
    }
}