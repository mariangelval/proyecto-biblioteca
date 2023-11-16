using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoAutor : Repo, IRepoAutor
{
    private const string _queryAutores =
        @"SELECT * FROM Autores";
    public RepoAutor(IDbConnection conexion, IDbTransaction transaccion)
        : base(conexion, transaccion) {}
    public void Alta(Autor autor)
    {
        var parametros= new DynamicParameters();
        parametros.Add("@unIdAutor", direction: ParameterDirection.Output);
        parametros.Add("@unNombre", autor.Nombre);
        parametros.Add("@unApellido", autor.Apellido);

        Conexion.Execute("altaAutores", parametros, Transaccion, commandType: CommandType.StoredProcedure);

        //Obtengo el valor de parametro de tipo salida
        autor.IdAutor = parametros.Get<ushort>("@unIdAutor");
    }

    public List<Autor> Obtener()
        =>  Conexion.
            Query<Autor>(_queryAutores, transaction: Transaccion).
            ToList();
}