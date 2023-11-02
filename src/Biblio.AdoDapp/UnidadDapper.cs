using System.Data;
using Biblio.Core;
using MySqlConnector;

namespace Biblio.AdoDapp;

public class UnidadDapper : IAdo
{
    private readonly IDbConnection _conexion;
    public UnidadDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public UnidadDapper(string cadena) => _conexion = new MySqlConnection(cadena);
    public void AltaAutor(Autor autor)
    {
        throw new NotImplementedException();
    }

    public List<Autor> ObtenerAutores()
    {
        throw new NotImplementedException();
    }
}
