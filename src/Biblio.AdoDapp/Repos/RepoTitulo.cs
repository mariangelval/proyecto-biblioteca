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

        public RepoTitulo(IDbConnection conexion, IDbTransaction transaccion)
        : base(conexion, transaccion) {}
        public void Alta(Titulo titulo)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@idTitulo", direction: ParameterDirection.Output);
            parametros.Add("@unNombre", titulo.Nombre);
            parametros.Add("@anioPrimero", autor.anioPrimero);

            Conexion.Execute("altaTitulos", parametros, Transaccion, CommandType.StoredProcedure);

            //Objeto el valor parametro de tipo de salida 
            titulo.idTitulo = parametros.Get<ushort>("@unIdTitulo");
        }

        //FALTA EL OBTENERRRRR !!!!!!!!!!!!!!!!!!!!!
    }
}