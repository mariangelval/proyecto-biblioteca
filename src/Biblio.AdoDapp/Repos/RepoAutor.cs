using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoAutor : Repo, IRepoAutor
{
    private const string _queryAutores =
        @"SELECT * FROM Autores";
    private const string _altaAutor =
        @"";
    public RepoAutor(IDbConnection conexion)
        : base(conexion) {}
    public void Alta(Autor elemento)
    {
        throw new NotImplementedException();
    }

    public List<Autor> Obtener()
        =>  Conexion.
            Query<Autor>(_queryAutores).
            ToList();
}