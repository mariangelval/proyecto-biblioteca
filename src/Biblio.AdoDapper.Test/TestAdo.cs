using Biblio.AdoDapp;
using Biblio.Core.Persistencia;

namespace Biblio.AdoDapper.Test;

public class TestAdo
{
    protected readonly IUnidad Unidad;
    private const string _cadena = "Server=localhost;Database=Biblioteca;Uid=test;pwd=test;Allow User Variables=True";

    public TestAdo() => Unidad = new UnidadDapper(_cadena);
    public TestAdo(string cadena) => Unidad = new UnidadDapper(cadena);
}
