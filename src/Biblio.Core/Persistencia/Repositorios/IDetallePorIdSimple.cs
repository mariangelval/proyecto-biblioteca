using System.Numerics;

namespace Biblio.Core.Persistencia.Repositorios;

/// <summary>
/// Interfaz para traer un elemento de T en base a un id simple
/// </summary>
/// <typeparam name="T">Entidad a traer</typeparam>
/// <typeparam name="N">Tipo del id del elemento T</typeparam>
public interface IDetallePorIdSimple<T, N>  where N: IBinaryNumber<N>
{
    T? Detalle (N id);
}