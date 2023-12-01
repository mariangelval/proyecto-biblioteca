using System.Data;
using System.Reflection.Metadata;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;
namespace Biblio.AdoDapp.Repos;

public class RepoFueraCirculacion : Repo<FueraCirculacion>, IRepoFueraCirculacion
{
    public RepoFueraCirculacion(UnidadDapper unidad) : base(unidad)
    {
    }

    protected override string QueryListado => @"SELECT * FROM FueraCirculacion";

    
    public void Alta(FueraCirculacion fueracirculacion)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unFecha_salida", fueracirculacion.FechaSalida);
        parametros.Add("@unNum_copia", fueracirculacion.NumCopia);
        parametros.Add("@unISBN", fueracirculacion.ISBN);

        EjecutarSP("altaFueraCirculacion", parametros);
    }

}