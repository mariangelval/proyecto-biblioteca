using Biblio.Core;

namespace Biblio.AdoDapper.Test;

public class TestAdoEditorial: TestAdo
{
    [Fact]
    public void AltaEditorial()
    {
        string nombre= "Oberon";
        var oberon= new Editorial()
        {
            Nombre= nombre
        };

        Assert.Equal(0, oberon.IdEditorial);

        Unidad.RepoEditorial.Alta(oberon);
        Unidad.Guardar();

        Assert.NotEqual(0, oberon.IdEditorial);
    }
    [Fact]
    public void Obtener()
    {
        var editoriales = Unidad.RepoEditorial.Obtener();

        Assert.NotEmpty(editoriales);
        Assert.Contains(editoriales, e => e.Nombre== "Planeta");
    }
}