using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos
{
    public class RepoTitulo: Repo
    {
        private const string _queryTitulos =
        @"SELECT * FROM Titulos";
        private const string _altaTitulo =
            @"";
        public RepoTitulo(IDbConnection conexion, IDbTransaction transaccion)
        : base(conexion, transaccion) {}
        public void Alta(Titulo elemento)
        {
            throw new NotImplementedException();
        }
    }
}