using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Entities;

namespace DataAccess
{
    /// <summary>
    /// Capa de acceso a datos para la entidad Barco.
    /// Usa Dapper para el mapeo O/R y métodos async para no bloquear el hilo de la UI.
    /// </summary>
    public class DALBarco
    {
        private static string Cadena => new Conexion().CadenaConexion;

        /// <summary>Inserta un nuevo barco mediante el SP correspondiente.</summary>
        public static async Task<bool> InsertarAsync(VOBarco barco)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                int rows = await cnn.ExecuteAsync("SP_InsertarBarco",
                    new
                    {
                        barco.Matricula,
                        barco.NoAmarre,
                        barco.Nombre,
                        barco.Cuota,
                        IdOwner    = barco.IdPersona,
                        UrlFoto    = barco.UrlFoto ?? ""
                    },
                    commandType: CommandType.StoredProcedure);
                return rows == 1;
            }
        }

        /// <summary>Actualiza un barco existente.</summary>
        public static async Task<bool> ActualizarAsync(VOBarco barco)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                int rows = await cnn.ExecuteAsync("SP_ActualizarBarco",
                    new
                    {
                        barco.IdBarco,
                        barco.Matricula,
                        barco.NoAmarre,
                        barco.Nombre,
                        barco.Cuota,
                        IdOwner        = barco.IdPersona,
                        UrlFoto        = barco.UrlFoto ?? "",
                        barco.Disponibilidad
                    },
                    commandType: CommandType.StoredProcedure);
                return rows == 1;
            }
        }

        /// <summary>Marca un barco como no disponible (eliminación lógica).</summary>
        public static async Task<bool> EliminarAsync(int idBarco)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                int rows = await cnn.ExecuteAsync("SP_EliminarBarco",
                    new { IdBarco = idBarco },
                    commandType: CommandType.StoredProcedure);
                return rows == 1;
            }
        }

        /// <summary>Consulta todos los barcos, con filtro opcional de disponibilidad.</summary>
        public static async Task<IEnumerable<VOBarco>> ConsultarTodosAsync(bool? disponibilidad = null)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryAsync<VOBarco>("SP_ConsultarBarcos",
                    new { Disponibilidad = disponibilidad },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Consulta un barco por su ID.</summary>
        public static async Task<VOBarco> ConsultarPorIdAsync(int idBarco)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryFirstOrDefaultAsync<VOBarco>("SP_ConsultarBarcoPorId",
                    new { IdBarco = idBarco },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}