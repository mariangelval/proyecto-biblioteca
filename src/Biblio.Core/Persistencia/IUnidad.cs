using Biblio.Core.Persistencia.Repositorios;

namespace Biblio.Core.Persistencia;
public interface IUnidad
{
    IRepoAutor RepoAutor { get; }
    IRepoCurso RepoCurso{get; }
    IRepoTitulo RepoTitulo{get; }
    void Guardar();
}