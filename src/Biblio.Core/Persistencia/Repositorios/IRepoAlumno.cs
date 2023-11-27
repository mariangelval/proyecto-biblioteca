namespace Biblio.Core.Persistencia.Repositorios;
    public interface IRepoAlumno : IAlta<Alumno>, IListado<Alumno>, IDetallePorIdSimple<Alumno, uint>
    {
        
    }