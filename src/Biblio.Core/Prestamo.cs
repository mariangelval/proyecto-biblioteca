using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.Core
{
    public class Prestamo
    {
        public ulong ISBN {get; set;}
        public byte NumCopia {get; set;}
        public DateTime FechaSalida {get; set;}
        public DateTime FechaRegreso {get; set;}

        public Alumno Alumno {get;set;}
        public Prestamo(Alumno alumno)
        {
            Alumno=alumno;
        }

    }
}