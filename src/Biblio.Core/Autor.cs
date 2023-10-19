namespace Biblio.Core;

public class Autor
{
    public ushort idAutor {get; set;}
    public required string nombre {get;set;}
    public required string apellido {get;set;}
}
public class Titulos
{
    public ushort idAutor {get; set;}
    public required string nombre {get;set;}
    public ushort anio_primero {get;set;}
}