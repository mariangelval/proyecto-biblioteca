using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.Core
{
    public class Ejemplares
    {
        public ulong ISBN {get; set;}
        public ushort idEditorial {get; set;}
        public byte cantCopias {get; set;}
        public ushort cantPrestamos {get; set;}
        public ushort idTitulo {get; set}
    }
}