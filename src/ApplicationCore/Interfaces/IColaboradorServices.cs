// IColaboradoresService.cs
public interface IColaboradoresService
{
    Task<IEnumerable<ColaboradorDto>> GetColaboradoresByFechaIngreso(DateTime fechaIngreso);
}
