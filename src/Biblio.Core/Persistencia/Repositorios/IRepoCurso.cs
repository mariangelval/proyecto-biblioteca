namespace Biblio.Core.Persistencia.Repositorios;

public interface IRepoCurso : IAlta<Curso>, IListado<Curso>, IDetallePorIdSimple<Curso, byte>
{
    
}