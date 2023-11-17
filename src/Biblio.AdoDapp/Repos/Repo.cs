using System.Data;

namespace Biblio.AdoDapp.Repos;
public abstract class Repo
{
    private IConTransaccion conTransaccion;
    protected IDbConnection Conexion { get; }
    protected IDbTransaction Transaccion
        => conTransaccion.Transaccion;
    public Repo(UnidadDapper unidad)
    {
        Conexion = unidad.Conexion;
        conTransaccion = unidad;
    }
}