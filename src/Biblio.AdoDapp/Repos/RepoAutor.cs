using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoAutor : Repo<Autor>, IRepoAutor
{
    protected override string QueryListado =>
        @"SELECT * FROM Autores";
    public RepoAutor(UnidadDapper unidad)
        : base(unidad) {}
    public void Alta(Autor autor)
    {
        var parametros= new DynamicParameters();
        parametros.Add("@unIdAutor", direction: ParameterDirection.Output);
        parametros.Add("@unNombre", autor.Nombre);
        parametros.Add("@unApellido", autor.Apellido);

        EjecutarSP("altaAutores", parametros);

        //Obtengo el valor de parametro de tipo salida
        autor.IdAutor = parametros.Get<ushort>("@unIdAutor");
    }
}