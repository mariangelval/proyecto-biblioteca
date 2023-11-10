using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos
{
    public class RepoCurso : Repo, IRepoCurso
    {
        private const string _queryCurso =
        @"SELECT * FROM Curso";
        private const string _altaCurso = @"";
        public RepoCurso(IDbConnection conexion) : base(conexion)
        {}
        public void Alta(Curso elemento)
        {
            throw new NotImplementedException();
        }
    }
}