using System.Data;

namespace Biblio.AdoDapp.Repos;
public abstract class Repo
{
    protected IDbConnection Conexion { get; }
    protected IDbTransaction Transaccion { get; }
    public Repo(IDbConnection conexion, IDbTransaction transaccion)
    {
        Conexion = conexion;
        Transaccion = transaccion;
    }
}