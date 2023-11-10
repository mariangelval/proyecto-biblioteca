using Biblio.Core;

namespace Biblio.AdoDapper.Test;
public class TestAdoCurso: TestAdo
{
    [Fact]
    public void AltaCurso()
    {
        byte anio = 5;
        byte division = 8;
        var curso = new Curso()
        {
            Anio = anio,
            Division = division
        };

        Unidad.RepoCurso.Alta(curso);

        Assert.NotEqual(0, curso.IdCurso);
    }
}