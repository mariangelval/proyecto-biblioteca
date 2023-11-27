using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoEditorial : Repo<Editorial>, IRepoEditorial
{
    protected override string QueryListado =>
    @"SELECT idEditorial, editorial nombre FROM Editoriales";

    public RepoEditorial(UnidadDapper unidad)
        :base(unidad){}

    public void Alta(Editorial editorial)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdEditorial", direction: ParameterDirection.Output);
        parametros.Add("@unEditorial", editorial.Nombre);

        EjecutarSP("altaEditoriales", parametros);

        //Obtengo el valor de parametro de tipo salida
        editorial.IdEditorial= parametros.Get<ushort>("@unIdEditorial");
    }
}