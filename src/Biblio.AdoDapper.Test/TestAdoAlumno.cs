using System.Collections;
using Biblio.Core;

namespace Biblio.AdoDapper.Test
{
    public class TestAdoAlumno : TestAdo
    {
        [Fact]
        public void AltaAlumnos()
        {
            uint dni = 95847780;
            string nombre = "Mariangel";
            string apellido = "Valerio";
            ulong celular = 1164505763;
            string email = "valeriomariangel855@gmail.com";
            string contrasenia = "1234";

            var alumno = new Alumno()
            {
                DNI = dni,
                Nombre = nombre,
                Apellido = apellido,
                Celular = celular,
                Email = email,
                Contrasenia = contrasenia
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
}