using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoTitulo : Repo<Titulo>, IRepoTitulo
{
    protected override string QueryListado =>
    @"SELECT * FROM Titulos";
    private const string _queryInsertTitulosAutores =
        @"INSERT INTO TitulosAutores(idTitulo, idAutor) VALUES(@unIdTitulo, @unIdAutor)";
    public RepoTitulo(UnidadDapper unidad)
    : base(unidad) { }
    public void Alta(Titulo titulo)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdTitulo", direction: ParameterDirection.Output);
        parametros.Add("@unNombre", titulo.Nombre);
        parametros.Add("@unanioPrimero", titulo.Anio_primero);

        EjecutarSP("altaTitulos", parametros);

        //Objeto el valor parametro de tipo de salida 
        titulo.IdTitulo = parametros.Get<ushort>("@unIdTitulo");

        var parametrosInsert = titulo.Autores.
            Select(a => new { unIdAutor = a.IdAutor, unIdTitulo = titulo.IdTitulo });

        Conexion.Execute(_queryInsertTitulosAutores, parametrosInsert, transaction: Transaccion);
    }
}