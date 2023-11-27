using Biblio.Core;

namespace Biblio.AdoDapper.Test;
public class TestAdoAlumno : TestAdo
{
    [Fact]
    public void AltaAlumnos()
    {
        uint dni = 45833694;
        string nombre = "Joel";
        string apellido = "Guerra";
        ulong celular = 1187654318;
        string email = "joel@gmail.com";
        string contrasenia = "4321";
        var curso58 = Unidad.RepoCurso.Obtener().First(c => c.IdCurso == 1);

        //TODO dar de alta un alumno sin curso
        var alumno = new Alumno()
        {
            DNI = dni,
            Nombre = nombre,
            Apellido = apellido,
            Celular = celular,
            Email = email,
            Contrasenia = contrasenia,
            Curso = curso58        
        };


        Unidad.RepoAlumno.Alta(alumno);
        Unidad.Guardar();
    }
    [Fact]
    public void Detalle()
    {
        var alumno = Unidad.RepoAlumno.Detalle(46912870);

        Assert.NotNull(alumno);
        Assert.Equal("Vanina", alumno.Nombre);

        Assert.NotNull(alumno.Curso);
        Assert.Equal(5, alumno.Curso.Anio);
    }
}