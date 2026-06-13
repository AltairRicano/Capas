using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Entities;

namespace DataAccess
{
    /// <summary>
    /// Capa de acceso a datos para la entidad Salida.
    /// Usa Dapper para el mapeo O/R y métodos async para no bloquear el hilo de la UI.
    /// </summary>
    public class DALSalida
    {
        private static string Cadena => new Conexion().CadenaConexion;

        /// <summary>
        /// Inserta una nueva salida. El SP también marca al barco y capitán como NO DISPONIBLES.
        /// </summary>
        public static async Task<bool> InsertarAsync(VOSalida salida)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                int rows = await cnn.ExecuteAsync("SP_InsertarSalida",
                    new
                    {
                        salida.FechaHoraSalida,
                        salida.Destino,
                        salida.Estado,
                        IdBarco   = salida.IdBarco,
                        IdCapitan = salida.IdCapitan
                    },
                    commandType: CommandType.StoredProcedure);
                return rows > 0;
            }
        }

        /// <summary>
        /// Finaliza una salida. El SP actualiza su estado y libera (disponibilidad=1) al barco y capitán.
        /// </summary>
        public static async Task<bool> FinalizarAsync(int idSalida, string estado = "Terminada")
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                int rows = await cnn.ExecuteAsync("SP_FinalizarSalida",
                    new { IdSalida = idSalida, Estado = estado },
                    commandType: CommandType.StoredProcedure);
                return rows > 0;
            }
        }

        /// <summary>
        /// Elimina lógicamente una salida (marca como ELIMINADA) sin liberar disponibilidad.
        /// </summary>
        public static async Task<bool> EliminarAsync(int idSalida)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                int rows = await cnn.ExecuteAsync("SP_EliminarSalida",
                    new { IdSalida = idSalida },
                    commandType: CommandType.StoredProcedure);
                return rows > 0;
            }
        }

        /// <summary>Consulta salidas extendidas (con datos de barco y capitán), con filtro opcional de estado.</summary>
        public static async Task<IEnumerable<VOSalidaExtendida>> ConsultarPorEstadoAsync(string estado = null)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryAsync<VOSalidaExtendida>("SP_ConsultarSalidasPorEstadoExtendida",
                    new { Estado = estado },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Consulta una salida extendida por su ID.</summary>
        public static async Task<VOSalidaExtendida> ConsultarPorIdAsync(int idSalida)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryFirstOrDefaultAsync<VOSalidaExtendida>("SP_ConsultarSalidasPorIdExtendida",
                    new { IdSalida = idSalida },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}