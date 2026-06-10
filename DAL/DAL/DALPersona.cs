using System;
using System.Collections.Generic;
using System.Data;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DALPersona
    {
        public static bool Insertar(VOPersona persona)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@Nombre",    SqlDbType.VarChar,  persona.Nombre),
                    new("@Direccion", SqlDbType.VarChar,  persona.Direccion),
                    new("@Telefono",  SqlDbType.NVarChar, persona.Telefono),
                    new("@Correo",    SqlDbType.VarChar,  persona.Correo),
                    new("@Cargo",     SqlDbType.Int,      persona.Cargo),
                    new("@UrlFoto",   SqlDbType.VarChar,  persona.UrlFoto)
                };
                return Consultas.EjecucionSinConsulta("SP_InsertarPersona", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo insertar el registro de persona: " + ex.Message);
            }
        }

        public static bool Actualizar(VOPersona persona)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdPersona",    SqlDbType.Int,      persona.IdPersona),
                    new("@Nombre",       SqlDbType.VarChar,  persona.Nombre),
                    new("@Direccion",    SqlDbType.VarChar,  persona.Direccion),
                    new("@Telefono",     SqlDbType.NVarChar, persona.Telefono),
                    new("@Correo",       SqlDbType.VarChar,  persona.Correo),
                    new("@Cargo",        SqlDbType.Int,      persona.Cargo),
                    new("@Disponibilidad",SqlDbType.Bit,     persona.Disponibilidad),
                    new("@UrlFoto",      SqlDbType.VarChar,  persona.UrlFoto)
                };
                return Consultas.EjecucionSinConsulta("SP_ActualizarPersona", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo actualizar el registro de persona: " + ex.Message);
            }
        }

        public static bool EliminarPersona(int idPersona)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdPersona", SqlDbType.Int, idPersona)
                };
                return Consultas.EjecucionSinConsulta("SP_EliminarPersona", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo eliminar el registro de persona: " + ex.Message);
            }
        }

        public static VOPersona ConsultarPersonaPorId(int idPersona)
        {
            VOPersona persona = null;
            Conexion conexion = new Conexion();
            using SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                using SqlCommand cmd = new SqlCommand("SP_ConsultarPersonaPorId", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@IdPersona", SqlDbType.Int).Value = idPersona;
                using SqlDataReader datos = cmd.ExecuteReader();
                if (datos.Read())
                {
                    persona = new VOPersona(
                        Convert.ToInt32(datos[0]),
                        datos[1].ToString(),
                        datos[2].ToString(),
                        datos[3].ToString(),
                        datos[4].ToString(),
                        Convert.ToInt32(datos[5]),
                        Convert.ToBoolean(datos[6]),
                        datos[7].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo completar la búsqueda: " + ex.Message);
            }
            return persona;
        }

        public static List<VOPersona> ConsultarPersonasPorCargo(int cargo, bool? disponibilidad)
        {
            var lista = new List<VOPersona>();
            Conexion conexion = new Conexion();
            using SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                using SqlCommand cmd = new SqlCommand("SP_ConsultarPersonasPorCargo", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Cargo", SqlDbType.Int).Value = cargo;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = (object)disponibilidad ?? DBNull.Value;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Personas");
                foreach (DataRow fila in ds.Tables[0].Rows)
                    lista.Add(new VOPersona(fila));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de Persona: " + ex.Message);
            }
            return lista;
        }

        public static List<VOPersona> ConsultarPersonas(bool? disponibilidad)
        {
            var lista = new List<VOPersona>();
            Conexion conexion = new Conexion();
            using SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                using SqlCommand cmd = new SqlCommand("SP_ConsultarPersonas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Disponibilidad", SqlDbType.Bit).Value = (object)disponibilidad ?? DBNull.Value;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Personas");
                foreach (DataRow fila in ds.Tables[0].Rows)
                    lista.Add(new VOPersona(fila));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de Persona: " + ex.Message);
            }
            return lista;
        }
    }
}
