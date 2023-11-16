using System.Data;
using Biblio.AdoDapp.Repos;
using Biblio.Core;
using Biblio.Core.Persistencia;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;
using MySqlConnector;

namespace Biblio.AdoDapp;

public class UnidadDapper : IUnidad
{
    private readonly IDbConnection _conexion;
    private readonly IDbTransaction _transaccion;
    private readonly RepoAutor _repoAutor;

    private readonly RepoCurso _repoCurso;
    public UnidadDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public UnidadDapper(string cadena)
    {
        _conexion = new MySqlConnection(cadena);
        _conexion.Open();
        _transaccion = _conexion.BeginTransaction();
        _repoAutor = new RepoAutor(_conexion, _transaccion);
        _repoCurso= new RepoCurso(_conexion, _transaccion);
    }
    

    public IRepoAutor RepoAutor => _repoAutor;
    public IRepoCurso RepoCurso => _repoCurso;
    public void Guardar()
    {
        _transaccion.Commit();        
    }
}
