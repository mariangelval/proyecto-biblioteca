namespace Biblio.Core.Persistencia.Repositorios;

public interface IAlta<T>
{
    void Alta(T elemento);
}