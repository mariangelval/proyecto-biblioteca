namespace Biblio.Core;
public class Titulo
{
    public ushort IdTitulo { get; set; }
    public required string Nombre { get; set; }
    public ushort Anio_primero { get; set; }
    public List<Autor> Autores {get;set;}
    public Titulo() => Autores = new();
    public Titulo(List<Autor> autores) => Autores = autores;
    public void AgregarAutor(Autor autor) => Autores.Add(autor);
}