using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;
namespace Biblio.AdoDapp.Repos;

public class RepoPrestamo : Repo<Prestamo>, IRepoPrestamo
{
    public RepoPrestamo(UnidadDapper unidad)
        : base(unidad) { }

    protected override string QueryListado => 
        @"SELECT * FROM Prestamos";
    private static readonly string _queryAltaPrestamo
        = @"INSERT INTO Prestamos VALUES (@unISBN, @unNumCopia, @unDNI, @unFechaSalida, @unFechaRegreso)";

    private static readonly string _queryDetallePrestamo
    = @"SELECT *
        FROM Prestamos
        WHERE "
    public void Alta(Prestamo prestamo)
        => Conexion.Execute(
            _queryAltaPrestamo,
            new
            {
                isbn= prestamo.Ejemplar.ISBN,
                num_copia= prestamo.NumCopia,
                dni= prestamo.Alumno.DNI,
                fecha_salida= prestamo.FechaSalida,
                fecha_regreso= prestamo.FechaRegreso
            }
        );

    public Prestamo? Detalle(ulong id)
    {
        throw new NotImplementedException();
    }
}