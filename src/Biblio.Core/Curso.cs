namespace Biblio.Core
{
    public class Curso
    {
        public byte IdCurso {get; set;}
        public byte Anio {get; set;}
        public byte Division {get; set;}
        public IEnumerable<Alumno> Alumnos { get; set; }
            = Array.Empty<Alumno>();
    }
}