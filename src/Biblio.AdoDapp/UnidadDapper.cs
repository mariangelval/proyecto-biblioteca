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
    public UnidadDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public UnidadDapper(string cadena)
    {
        _conexion = new MySqlConnection(cadena);
        _conexion.Open();
        _transaccion = _conexion.BeginTransaction();
        _repoAutor = new RepoAutor(this);
        _repoCurso= new RepoCurso(this);
    }
    

    public IRepoAutor RepoAutor => _repoAutor;
    public IRepoCurso RepoCurso => _repoCurso;
    public IDbConnection Conexion => _conexion;

    public IDbTransaction Transaccion => _transaccion;
    public void Guardar()
    {
        _transaccion.Commit();
        _transaccion = _conexion.BeginTransaction();
    }
}
