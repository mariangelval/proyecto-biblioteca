using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.Core.Persistencia.Repositorios
{
    public interface IRepoEjemplar: IAlta<Ejemplar>, IListado<Ejemplar>, IDetallePorIdSimple<Ejemplar, ulong>
    {
        
    }
}