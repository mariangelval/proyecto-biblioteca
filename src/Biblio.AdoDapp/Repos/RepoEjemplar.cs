using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;
namespace Biblio.AdoDapp.Repos;
public class RepoEjemplar : Repo<Ejemplar>, IRepoEjemplar
{
    protected override string QueryListado => 
        @"SELECT * FROM Ejemplares";

    private static readonly string _queryDetalleEjemplar
    = @"SELECT *
        FROM Ejemplares
        WHERE ISBN=@id
        
        SELECT *
        FROM Editoriales
        JOIN Ejemplares USING (idEditorial)
        WHERE ISBN=@id
        
        SELECT *
        FROM Titulos
        JOIN Ejemplares USING (idTitulo)
        WHERE ISBN= @id";
    public RepoEjemplar(UnidadDapper unidad)
        : base(unidad) { }

    public void Alta(Ejemplar ejemplar)
    {
        var parametros= new DynamicParameters();
        parametros.Add("@unISBN",ejemplar.ISBN);
        parametros.Add("@unIdEditorial", ejemplar.Editorial is null?
                                            null:
                                            ejemplar.Editorial.IdEditorial);
        parametros.Add("@unCant_copias", ejemplar.cantCopias);
        parametros.Add("@unIdTitulo", ejemplar.Titulo is null?
                                            null:
                                            ejemplar.Titulo.IdTitulo);
        parametros.Add("@unCant_prestamos", ejemplar.cantPrestamos);

        EjecutarSP("altaEjemplares", parametros);
    }

    public Ejemplar? Detalle(ulong ISBN)
    {
        //TODO evaluar usar JOIN y spliton
        using(var multi= Conexion.QueryMultiple(_queryDetalleEjemplar, new {id=ISBN}, transaction: Transaccion))
        {
            var ejemplar=multi.ReadSingleOrDefault<Ejemplar>();
            if(ejemplar is not null)
            {
                ejemplar.Titulo=multi.ReadSingle<Titulo>();
                ejemplar.Editorial=multi.ReadSingle<Editorial>();
            }
            return ejemplar;
        }
    }
}
