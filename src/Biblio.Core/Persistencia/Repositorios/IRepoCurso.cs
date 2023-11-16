using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblio.Core.Persistencia.Repositorios
{
    public interface IRepoCurso : IAlta<Curso>, IListado<Curso>
    {
        
    }
}