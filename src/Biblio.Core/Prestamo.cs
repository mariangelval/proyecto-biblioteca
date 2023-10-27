namespace Biblio.Core;

public class Prestamo
{
    public ulong ISBN { get; set; }
    public byte NumCopia { get; set; }
    public DateTime FechaSalida { get; set; }
    public DateTime FechaRegreso { get; set; }
    public Ejemplar Ejemplar { get; set; }
    public Alumno Alumno { get; set; }
    public Prestamo(Alumno alumno, Ejemplar ejemplar)
    {
        Alumno = alumno;
        Ejemplar = ejemplar;
        FechaSalida = DateTime.Now;
    }


}