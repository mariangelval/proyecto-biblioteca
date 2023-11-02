using System.Data;

namespace Biblio.AdoDapp.Repos;

public abstract class Repo
{
    protected IDbConnection Conexion { get; }
    public Repo(IDbConnection conexion)
        => Conexion = conexion;
}