using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoCurso : Repo<Curso>, IRepoCurso
{
    protected override string QueryListado =>
        @"SELECT * FROM Cursos";
    private const string _altaCurso =
        @"";
    private static readonly string _queryDetalleCurso
    = @"SELECT * 
            FROM Cursos
            WHERE idCurso= @id;

            SELECT *
            FROM Alumnos
            WHERE idCurso= @id;";
    public RepoCurso(UnidadDapper unidad)
    : base(unidad) {}
    public void Alta(Curso elemento)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdCurso", direction: ParameterDirection.Output);
        parametros.Add("@unAnio", elemento.Anio);
        parametros.Add("@unDivision", elemento.Division);

        EjecutarSP("altaCursos", parametros);

        //Obtengo el valor de parametro de tipo salida
        elemento.IdCurso = parametros.Get<byte>("@unIdCurso");
    }

    public Curso? Detalle<N>(N id) where N : System.Numerics.IBinaryNumber<N>
    {
        using (var multi= Conexion.QueryMultiple(_queryDetalleCurso, new {id= id}, transaction: Transaccion))
        {
            var curso= multi.ReadSingleOrDefault<Curso>();
            if(curso is not null)
            {
                curso.Alumnos = multi.Read<Alumno>();
                //TODO asignar este curso a cada alumno
            }
            return curso;
        }
    }
}