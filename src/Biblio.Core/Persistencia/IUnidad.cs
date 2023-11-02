using Biblio.Core.Persistencia.Repositorios;

namespace Biblio.Core.Persistencia;
public interface IUnidad
{
    IRepoAutor RepoAutor { get; }
    void Guardar();
}