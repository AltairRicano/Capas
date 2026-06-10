using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public struct Parametros
    {
        public Parametros(string nombre, SqlDbType tipo, object valor)
        {
            Nombre = nombre;
            Tipo = tipo;
            Valor = valor;
        }

        public string Nombre { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }
    }

    public class Consultas
    {
        /// <summary>Ejecuta un SP sin retorno de datos (INSERT, UPDATE, DELETE).</summary>
        public static int EjecucionSinConsulta(string spNombre, List<Parametros> parametros)
        {
            int rows = 0;
            Conexion conexion = new Conexion();
            using SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                using SqlCommand cmd = new SqlCommand(spNombre, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in parametros)
                    cmd.Parameters.Add(p.Nombre, p.Tipo).Value = p.Valor ?? DBNull.Value;
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al ejecutar la consulta: " + ex.Message);
            }
            return rows;
        }

        /// <summary>Ejecuta un SP y retorna una lista plana de objetos (primera fila).</summary>
        public static List<object> EjecucionConLectura(string spNombre, List<Parametros> parametros)
        {
            List<object> registro = new List<object>();
            Conexion conexion = new Conexion();
            using SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                using SqlCommand cmd = new SqlCommand(spNombre, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in parametros)
                    cmd.Parameters.Add(p.Nombre, p.Tipo).Value = p.Valor ?? DBNull.Value;
                using SqlDataReader datos = cmd.ExecuteReader();
                while (datos.Read())
                    for (int i = 0; i < datos.FieldCount; i++)
                        registro.Add(datos.GetValue(i));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al ejecutar consulta: " + ex.Message);
            }
            return registro;
        }

        /// <summary>Ejecuta un SP y retorna un DataTable con todos los registros.</summary>
        public static DataTable EjecucionConLlenado(string spNombre, List<Parametros> parametros)
        {
            DataSet ds = new DataSet();
            Conexion conexion = new Conexion();
            using SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                using SqlCommand cmd = new SqlCommand(spNombre, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (var p in parametros)
                    cmd.Parameters.Add(p.Nombre, p.Tipo).Value = p.Valor ?? DBNull.Value;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Resultados");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al ejecutar consulta: " + ex.Message);
            }
            return ds.Tables["Resultados"];
        }
    }
}
