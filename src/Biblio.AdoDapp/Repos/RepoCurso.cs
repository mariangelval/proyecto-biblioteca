using System.Data;
using Biblio.Core;
using Biblio.Core.Persistencia.Repositorios;
using Dapper;

namespace Biblio.AdoDapp.Repos;
public class RepoCurso : Repo<Curso>, IRepoCurso
{
    protected override string QueryListado =>
        @"SELECT * FROM Cursos";
    private static readonly string _queryDetalleCurso
    = @"SELECT * 
            FROM Cursos
            WHERE idCurso= @id;

            SELECT *
            FROM Alumnos
            WHERE idCurso= @id;";
    public RepoCurso(UnidadDapper unidad)
    : base(unidad) { }
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

    public Curso? Detalle(byte idCurso)
    {
        using (var multi = Conexion.QueryMultiple(_queryDetalleCurso, new { id = idCurso }, transaction: Transaccion))
        {
            var curso = multi.ReadSingleOrDefault<Curso>();
            if (curso is not null)
            {
                curso.Alumnos = multi.Read<Alumno>();
                foreach (Alumno alumno in curso.Alumnos)
                {
                    alumno.Curso = curso;
                }
            }
            return curso;
        }
    }
}