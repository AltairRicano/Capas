using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Entities;

namespace DataAccess
{
    /// <summary>
    /// Capa de acceso a datos para la entidad Persona.
    /// Usa Dapper para el mapeo O/R y métodos async para no bloquear el hilo de la UI.
    /// </summary>
    public class DALPersona
    {
        private static string Cadena => new Conexion().CadenaConexion;

        /// <summary>Inserta una nueva persona.</summary>
        public static async Task InsertarAsync(VOPersona persona)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                await cnn.ExecuteAsync("SP_InsertarPersona",
                    new
                    {
                        persona.Nombre,
                        persona.Direccion,
                        persona.Telefono,
                        persona.Correo,
                        persona.Cargo,
                        UrlFoto = persona.UrlFoto ?? ""
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Actualiza los datos de una persona.</summary>
        public static async Task ActualizarAsync(VOPersona persona)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                await cnn.ExecuteAsync("SP_ActualizarPersona",
                    new
                    {
                        persona.IdPersona,
                        persona.Nombre,
                        persona.Direccion,
                        persona.Telefono,
                        persona.Correo,
                        persona.Cargo,
                        UrlFoto        = persona.UrlFoto ?? "",
                        persona.Disponibilidad
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Marca una persona como no disponible (eliminación lógica).</summary>
        public static async Task EliminarAsync(int idPersona)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                await cnn.ExecuteAsync("SP_EliminarPersona",
                    new { IdPersona = idPersona },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Consulta una persona por su ID.</summary>
        public static async Task<VOPersona> ConsultarPorIdAsync(int idPersona)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryFirstOrDefaultAsync<VOPersona>("SP_ConsultarPersonaPorId",
                    new { IdPersona = idPersona },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Consulta todas las personas, con filtro opcional de disponibilidad.</summary>
        public static async Task<IEnumerable<VOPersona>> ConsultarTodasAsync(bool? disponibilidad = null)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryAsync<VOPersona>("SP_ConsultarPersonas",
                    new { Disponibilidad = disponibilidad },
                    commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>Consulta personas filtradas por cargo y disponibilidad.</summary>
        public static async Task<IEnumerable<VOPersona>> ConsultarPorCargoAsync(int cargo, bool? disponibilidad = null)
        {
            using (IDbConnection cnn = new SqlConnection(Cadena))
            {
                return await cnn.QueryAsync<VOPersona>("SP_ConsultarPersonasPorCargo",
                    new { Cargo = cargo, Disponibilidad = disponibilidad },
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
