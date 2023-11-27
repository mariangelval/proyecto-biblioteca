using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;

namespace Biblio.AdoDapp.Repos;
public class RepoEjemplar : Repo<Ejemplar>, IRepoEjemplar
{
    protected override string QueryListado => throw new NotImplementedException();
    public RepoEjemplar(UnidadDapper unidad)
        : base(unidad) { }
}
