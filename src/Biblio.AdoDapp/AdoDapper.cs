using System.Data;
using Biblio.Core;
using MySqlConnector;

namespace Biblio.AdoDapp;

public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;
    public AdoDapper(IDbConnection conexion) => this._conexion = conexion;

    //Este constructor usa por defecto la cadena para un conector MySQL
    public AdoDapper(string cadena) => _conexion = new MySqlConnection(cadena);
    public void AltaAutor(Autor autor)
    {
        throw new NotImplementedException();
    }

    public List<Autor> ObtenerAutores()
    {
        throw new NotImplementedException();
    }
}
