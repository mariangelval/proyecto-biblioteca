namespace Biblio.Core
{
    public class Alumno
    {
        public uint DNI {get; set;}
        public required string Nombre {get; set;}
        public required string Apellido {get; set;}
        public ulong Celular {get; set;}
        public required string Email {get; set;} 
        public required string Contrasenia {get; set;}

        public Curso? Curso { get; set; }
    }
}