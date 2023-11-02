namespace Biblio.Core.Persistencia.Repositorios;

public interface IListado<T>
{
    public List<T> Obtener();
}