using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Consultas
    {
        public static int EjecucionSinConsulta(string spNombre, List<Parametros> parametros)
        {
            int rows = 0;
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(spNombre, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parametros p in parametros)
                    cmd.Parameters.Add(p.Nombre, p.Tipo).Value = p.Valor;
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al ejecutar la consulta: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return rows;
        }

        public static DataTable EjecucionConLlenado(string spNombre, List<Parametros> parametros)
        {
            Conexion conexion = new Conexion();
            SqlConnection cnn = new SqlConnection(conexion.CadenaConexion);
            DataSet ds = new DataSet();
            try
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(spNombre, cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (Parametros p in parametros)
                    cmd.Parameters.Add(p.Nombre, p.Tipo).Value = p.Valor;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds, "Resultados");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al ejecutar consulta: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }
            return ds.Tables["Resultados"];
        }
    }
}