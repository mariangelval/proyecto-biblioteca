using Biblio.Core;
namespace Biblio.AdoDapper.Test;

public class TestAdoEjemplar : TestAdo
{
    [Fact]
    public void AltaEjemplar()
    {
        ulong isbn = 318434094435345;
        byte cantcopias = 30;
        ushort cantprestamos = 0;

        var editorial = Unidad.RepoEditorial.Obtener().First();
        var titulo = Unidad.RepoTitulo.Obtener().First(t => t.IdTitulo == 3);

        var ejemplar = new Ejemplar(editorial, titulo)
        {
            ISBN = isbn,
            cantCopias = cantcopias,
            cantPrestamos = cantprestamos
        };

        Unidad.RepoEjemplar.Alta(ejemplar);
        Unidad.Guardar();
    }
    [Fact]
    public void Detalle()
    {
        var ejemplar = Unidad.RepoEjemplar.Detalle(318434094435345);

        Assert.NotNull(ejemplar);
    }
}