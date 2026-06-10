using System;
using System.Collections.Generic;
using System.Data;
using Entidades;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DALBarco
    {
        public static bool Insertar(VOBarco barco)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@Matricula", SqlDbType.VarChar, barco.Matricula),
                    new("@NoAmarre",  SqlDbType.VarChar, barco.NoAmarre),
                    new("@Nombre",    SqlDbType.VarChar, barco.Nombre),
                    new("@Cuota",     SqlDbType.Decimal, barco.Cuota),
                    new("@IdOwner",   SqlDbType.Int,     barco.IdPersona),
                    new("@UrlFoto",   SqlDbType.VarChar, barco.UrlFoto)
                };
                return Consultas.EjecucionSinConsulta("SP_InsertarBarco", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos: " + ex.Message);
            }
        }

        public static bool Actualizar(VOBarco barco)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdBarco",       SqlDbType.Int,     barco.IdBarco),
                    new("@Matricula",     SqlDbType.VarChar, barco.Matricula),
                    new("@NoAmarre",      SqlDbType.VarChar, barco.NoAmarre),
                    new("@Nombre",        SqlDbType.VarChar, barco.Nombre),
                    new("@Cuota",         SqlDbType.Decimal, barco.Cuota),
                    new("@IdOwner",       SqlDbType.Int,     barco.IdPersona),
                    new("@UrlFoto",       SqlDbType.VarChar, barco.UrlFoto),
                    new("@Disponibilidad",SqlDbType.Bit,     barco.Disponibilidad)
                };
                return Consultas.EjecucionSinConsulta("SP_ActualizarBarco", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo actualizar en la base de datos: " + ex.Message);
            }
        }

        public static bool Eliminar(int idBarco)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdBarco", SqlDbType.Int, idBarco)
                };
                return Consultas.EjecucionSinConsulta("SP_EliminarBarco", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo eliminar en la base de datos: " + ex.Message);
            }
        }

        public static VOBarco ConsultarBarco(int idBarco)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdBarco", SqlDbType.Int, idBarco)
                };
                var datos = Consultas.EjecucionConLectura("SP_ConsultarBarcoPorId", parametros);
                return new VOBarco(datos);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar en la base de datos: " + ex.Message);
            }
        }

        public static List<VOBarco> ConsultarBarcos(bool? disponibilidad)
        {
            var lista = new List<VOBarco>();
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@Disponibilidad", SqlDbType.Bit, (object)disponibilidad ?? DBNull.Value)
                };
                DataTable barcos = Consultas.EjecucionConLlenado("SP_ConsultarBarcos", parametros);
                foreach (DataRow registro in barcos.Rows)
                    lista.Add(new VOBarco(registro));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar en la base de datos: " + ex.Message);
            }
            return lista;
        }

        public static List<VOBarco> ConsultarBarcosPorOwner(int idOwner, bool? disponibilidad)
        {
            var lista = new List<VOBarco>();
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdOwner",       SqlDbType.Int, idOwner),
                    new("@Disponibilidad",SqlDbType.Bit, (object)disponibilidad ?? DBNull.Value)
                };
                DataTable barcos = Consultas.EjecucionConLlenado("SP_ConsultarBarcosPorOwner", parametros);
                foreach (DataRow registro in barcos.Rows)
                    lista.Add(new VOBarco(registro));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar en la base de datos: " + ex.Message);
            }
            return lista;
        }
    }
}
