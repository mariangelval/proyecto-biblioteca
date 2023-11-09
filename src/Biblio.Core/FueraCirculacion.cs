namespace Biblio.Core;
public class FueraCirculacion
{
    public DateTime FechaSalida { get; set; }
    public byte NumCopia { get; set; }

    public ulong ISBN { get; set; }
    public FueraCirculacion(ulong isbn) => ISBN = isbn;
}