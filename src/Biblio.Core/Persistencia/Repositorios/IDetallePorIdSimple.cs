using System.Numerics;

namespace Biblio.Core.Persistencia.Repositorios;

public interface IDetallePorIdSimple<T>
{
    T? Detalle<N> (N id) where N: IBinaryNumber<N>;
}