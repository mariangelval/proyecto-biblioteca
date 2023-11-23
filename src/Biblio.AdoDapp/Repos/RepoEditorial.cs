using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;
namespace Biblio.AdoDapp.Repos;

public class RepoEditorial : Repo, IRepoEditorial
{
    private const string _queryEditorial=
    @"SELECT * FROM Editoriales";

    public RepoEditorial(UnidadDapper unidad)
        :base(unidad){}

    public void Alta(Editorial editorial)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdEditorial", direction: ParameterDirection.Output);
        parametros.Add("@unEditorial", editorial.Nombre);

        Conexion.Execute("altaEditoriales", parametros, Transaccion, CommandType: CommandType.StoredProcedure);

        editorial.IdEditorial= parametros.Get<ushort>("@unIdEditorial");
    }
    
}