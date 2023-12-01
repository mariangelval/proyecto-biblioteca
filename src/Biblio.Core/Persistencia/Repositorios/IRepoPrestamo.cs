namespace Biblio.Core.Persistencia.Repositorios;

public interface IRepoPrestamo: IAlta<Prestamo>, IListado<Prestamo>, IDetallePorIdSimple<Prestamo, ulong>
{
    
}