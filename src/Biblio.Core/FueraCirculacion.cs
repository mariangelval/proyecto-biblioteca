using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.Core
{
    public class FueraCirculacion
    {
        public DateTime FechaSalida {get; set;}
        public byte NumCopia {get; set;}

        public  Ejemplar Ejemplar {get;set;}
        public FueraCirculacion(Ejemplar ejemplares)
        {
            Ejemplar=ejemplares;
        }
    }
}