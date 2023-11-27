using System.Data;
using Biblio.AdoDapp.Repos;
using Biblio.Core.Persistencia;
using Biblio.Core.Persistencia.Repositorios;
using MySqlConnector;

namespace Biblio.AdoDapp;

public class UnidadDapper : IUnidad, IConTransaccion
{
    private readonly IDbConnection _conexion;
    private IDbTransaction _transaccion;
    private readonly RepoAutor _repoAutor;
    private readonly RepoCurso _repoCurso;
    private readonly RepoTitulo _repoTitulo;
    private readonly RepoEditorial _repoEditorial;
    private readonly RepoAlumno _repoAlumno;
    private readonly RepoEjemplar _repoEjemplar;
    public UnidadDapper(IDbConnection conexion)
    {
        _conexion = conexion;
        _conexion.Open();
        _transaccion = _conexion.BeginTransaction();
        _repoAutor = new RepoAutor(this);
        _repoCurso = new RepoCurso(this);
        _repoTitulo = new RepoTitulo(this);
        _repoEditorial = new RepoEditorial(this);
        _repoAlumno = new RepoAlumno(this);
        _repoEjemplar = new RepoEjemplar(this);
    }

    //Este constructor usa por defecto la cadena para un conector MySQL
    public UnidadDapper(string cadena)
        : this(new MySqlConnection(cadena)) { }

    public IRepoAutor RepoAutor => _repoAutor;
    public IRepoCurso RepoCurso => _repoCurso;
    public IRepoTitulo RepoTitulo => _repoTitulo;
    public IRepoEditorial RepoEditorial => _repoEditorial;
    public IRepoAlumno RepoAlumno => _repoAlumno;
    public IRepoEjemplar RepoEjemplar => _repoEjemplar;
    public IDbConnection Conexion => _conexion;
    public IDbTransaction Transaccion => _transaccion;

    public void Guardar()
    {
        _transaccion.Commit();
        _transaccion = _conexion.BeginTransaction();
    }
}
