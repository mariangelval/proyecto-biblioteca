using Biblio.Core;

namespace Biblio.AdoDapper.Test;
public class TestAdoTitulo : TestAdo
{
    [Fact]
    public void AltaTitulo()
    {
        string nombre = "El Gran Gatsby";
        ushort anioPrimero = 1925;

        var autores = Unidad.RepoAutor.Obtener();
        Assert.NotEmpty(autores);

        var titulo = new Titulo()
        {
            Nombre = nombre,
            Anio_primero = anioPrimero,
            Autores = autores
        };


        Assert.Equal(0, titulo.IdTitulo);
        
        Unidad.RepoTitulo.Alta(titulo);
        Unidad.Guardar();

        Assert.NotEqual(0, titulo.IdTitulo);
    }

    [Fact]

    public void Obtener()
    {
        var titulos = Unidad.RepoTitulo.Obtener();

        Assert.NotEmpty(titulos);
        Assert.Contains(titulos, t => t.Nombre == "El Gran Gatsby" && t.Anio_primero == 1925);
    }
}