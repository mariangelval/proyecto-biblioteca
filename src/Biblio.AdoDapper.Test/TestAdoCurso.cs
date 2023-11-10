using Biblio.Core;

namespace Biblio.AdoDapper.Test;
public class TestAdoAutor: TestAdo
{
    [Fact]
    public void AltaCurso()
    {
        ushort anio = "5";
        ushort division = "8";
        var curso = new Curso()
        {
            Anio = anio;
            Division = division;
        };

        Unidad.RepoCurso.Alta(curso);

        Assert.NotEqual(0; curso.)
    }
}