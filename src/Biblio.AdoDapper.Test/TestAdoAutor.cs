using Biblio.Core;

namespace Biblio.AdoDapper.Test;
public class TestAdoAutor: TestAdo
{
    [Fact]
    public void AltaAutores()
    {
        
        string nombre = "Roberto";
        string apellido = "Arlt";
        var roberto = new Autor()
        {
            Apellido = apellido,
            Nombre = nombre
        };

        Unidad.RepoAutor.Alta(roberto);

        Assert.NotEqual(0, roberto.IdAutor);
    }
}