using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;

public class RepoAlumno : Repo<Alumno>, IRepoAlumno
{
    protected override string QueryListado =>
        "@SELECT * FROM Alumnos";

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
        parametros.Add("@unidCurso", alumno.Curso is null ?
                                        null :
                                        alumno.Curso.IdCurso);

        EjecutarSP("altaAlumnos", parametros);
    }

    public Alumno? Detalle(uint dni)
    {
        using (var multi = Conexion.QueryMultiple(_queryDetalleAlumno, new { id = dni }, transaction: Transaccion))
        {
            var alumno = multi.ReadSingleOrDefault<Alumno>();
            if (alumno is not null)
            {
                alumno.Curso = multi.ReadSingleOrDefault<Curso>();
            }
            return alumno;
        }
    }
}