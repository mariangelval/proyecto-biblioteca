namespace Biblio.Core;
public class Titulo
{
    public ushort IdAutor { get; set; }
    public required string Nombre { get; set; }
    public ushort Anio_primero { get; set; }
    public List<Autor> Autores {get;set;}

    public Titulo()
    {
        Autores=new();
    }
}