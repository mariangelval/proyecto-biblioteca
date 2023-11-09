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
    private readonly RepoAutor _repoAutor;
    public UnidadDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public UnidadDapper(string cadena)
    {
        _conexion = new MySqlConnection(cadena);
        _repoAutor = new RepoAutor(_conexion);
    }

    public IRepoAutor RepoAutor => _repoAutor;

    public void AltaAutor(Autor autor)
    {
        var parametros= new DynamicParameters();
        parametros.Add("@unIdAutor", direction: ParameterDirection.Output);
        parametros.Add("@unNombre", autor.Nombre);
        parametros.Add("@unApellido", autor.Apellido);

        _conexion.Execute("altaAutores", parametros);

        //Obtengo el valor de parametro de tipo salida
        autor.IdAutor = parametros.Get<ushort>("@unIdAutor");
    }

    public void Guardar()
    {
        throw new NotImplementedException();
    }

    public List<Autor> ObtenerAutores()
    {
        throw new NotImplementedException();
    }
}
