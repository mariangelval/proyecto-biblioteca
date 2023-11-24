using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;

public class RepoAlumno : Repo, IRepoAlumno
{
    private const string _queryAlumnos =
        "@SELECT * FROM Alumnos";

    private const string _altaAlumnos =
        @"";

    private static readonly string _queryDetalleAlumno
    = @"SELECT *
        FROM Alumnos
        WHERE dni= @id;

        SELECT * 
        FROM Cursos 
        JOIN Alumnos USING(idCurso)
        WHERE dni= @id;";
    public RepoAlumno(UnidadDapper unidad)
        : base(unidad) { }
    public void Alta(Alumno alumno)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unDNI", alumno.DNI);
        parametros.Add("@unNombre", alumno.Nombre);
        parametros.Add("@unApellido", alumno.Apellido);
        parametros.Add("@unCelular", alumno.Celular);
        parametros.Add("@unEmail", alumno.Email);
        parametros.Add("@unContrasenia", alumno.Contrasenia);

        Conexion.Execute("altaAlumnos", parametros, Transaccion, commandType: CommandType.StoredProcedure);
    }

    public Alumno? Detalle<N>(N id) where N : System.Numerics.IBinaryNumber<N>
    {
        using (var multi = Conexion.QueryMultiple(_queryDetalleAlumno, new { id = id }, transaction: Transaccion))
        {
            var alumno = multi.ReadSingleOrDefault<Alumno>();
            if (alumno is not null)
            {
                alumno.Curso = multi.ReadSingleOrDefault<Curso>();
            }
            return alumno;
        }
    }

    public List<Alumno> Obtener()
        => Conexion.
            Query<Alumno>(_queryAlumnos, transaction: Transaccion).
            ToList();
}