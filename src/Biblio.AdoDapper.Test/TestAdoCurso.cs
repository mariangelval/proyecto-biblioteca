using Biblio.Core;

namespace Biblio.AdoDapper.Test;
public class TestAdoCurso : TestAdo
{
    [Fact]
    public void AltaCurso()
    {
        byte anio = 6;
        byte division = 8;

        var curso = new Curso()
        {
            Anio = anio,
            Division = division
        };

        Assert.Equal(0, curso.IdCurso);

        Unidad.RepoCurso.Alta(curso);
        Unidad.Guardar();

        Assert.NotEqual(0, curso.IdCurso);
    }
    [Fact]
    public void Obtener()
    {
        var cursos = Unidad.RepoCurso.Obtener();

        Assert.NotEmpty(cursos);
        Assert.Contains(cursos, c => c.Anio == 5 && c.Division == 8);
    }
}