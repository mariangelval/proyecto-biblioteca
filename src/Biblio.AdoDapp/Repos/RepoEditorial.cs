using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;
namespace Biblio.AdoDapp.Repos;

public class RepoEditorial : Repo, IRepoEditorial
{
    private const string _queryEditorial=
    @"SELECT idEditorial, editorial nombre FROM Editoriales";

    public RepoEditorial(UnidadDapper unidad)
        :base(unidad){}

    public void Alta(Editorial editorial)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdEditorial", direction: ParameterDirection.Output);
        parametros.Add("@unEditorial", editorial.Nombre);

        Conexion.Execute("altaEditoriales", parametros, Transaccion, commandType: CommandType.StoredProcedure);

        //Obtengo el valor de parametro de tipo salida
        editorial.IdEditorial= parametros.Get<ushort>("@unIdEditorial");
    }

    public List<Editorial> Obtener()
    => Conexion.
        Query<Editorial>(_queryEditorial, transaction: Transaccion).
        ToList();

    
}