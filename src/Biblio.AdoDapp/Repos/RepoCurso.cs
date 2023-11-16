using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos
{
    public class RepoCurso : Repo, IRepoCurso
    {
        private const string _queryCurso =
            @"SELECT * FROM Cursos";
        private const string _altaCurso =
            @"";
        public RepoCurso(IDbConnection conexion, IDbTransaction transaccion)
        : base(conexion, transaccion) { }
        public void Alta(Curso elemento)
        {
            var parametros = new DynamicParameters();
            parametros.Add("@unIdCurso", direction: ParameterDirection.Output);
            parametros.Add("@unAnio", elemento.Anio);
            parametros.Add("@unDivision", elemento.Division);

            Conexion.Execute("altaCursos", parametros, Transaccion, commandType: CommandType.StoredProcedure);

            //Obtengo el valor de parametro de tipo salida
            elemento.IdCurso = parametros.Get<byte>("@unIdCurso");
        }
        public List<Curso> Obtener()
        => Conexion.
            Query<Curso>(_queryCurso, transaction: Transaccion).
            ToList();

    }
}