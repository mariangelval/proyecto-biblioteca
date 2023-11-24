namespace Biblio.Core;

public class Ejemplar
{
    public ulong ISBN { get; set; }

    public byte cantCopias { get; set; }
    public ushort cantPrestamos { get; set; }
    public Editorial Editorial { get; set; }
    public Titulo Titulo { get; set; }

    public Ejemplar(Editorial editorial, Titulo titulo)
    {
        Editorial = editorial;
        Titulo = titulo;
    }

}