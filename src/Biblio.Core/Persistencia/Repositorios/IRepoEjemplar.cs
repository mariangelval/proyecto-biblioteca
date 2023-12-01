namespace Biblio.Core.Persistencia.Repositorios;

public interface IRepoEjemplar: IAlta<Ejemplar>, IListado<Ejemplar>, IDetallePorIdSimple<Ejemplar, ulong>
{
    
}