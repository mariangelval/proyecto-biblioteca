using System.Data;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public abstract class Repo<T> : IListado<T>
{
    private IConTransaccion conTransaccion;
    protected IDbConnection Conexion { get; }
    protected IDbTransaction Transaccion
        => conTransaccion.Transaccion;
    /// <summary>
    /// Propiedad usada por el método Obtener()
    /// </summary>
    /// <value>Cadena con la query</value>
    protected abstract string QueryListado { get; }
    public Repo(UnidadDapper unidad)
    {
        Conexion = unidad.Conexion;
        conTransaccion = unidad;
    }

    public virtual List<T> Obtener()
        => Conexion.
            Query<T>(QueryListado, param: null, Transaccion).
            ToList();

    /// <summary>
    /// Método para ejecutar un SP usando la transacción
    /// </summary>
    /// <param name="nombre">Nombre del SP</param>
    /// <param name="parametros">Lista de parametros</param>
    protected void EjecutarSP(string nombre, object? parametros)
        => Conexion.Execute(nombre, parametros, Transaccion, commandType: CommandType.StoredProcedure);
}