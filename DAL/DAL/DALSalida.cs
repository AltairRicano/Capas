using System;
using System.Collections.Generic;
using System.Data;
using Entidades;

namespace DAL
{
    public class DALSalida
    {
        public static bool InsertarSalida(VOSalida salida)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@FechaHoraSalida", SqlDbType.DateTime, salida.FechaHoraSalida),
                    new("@Destino",         SqlDbType.VarChar,  salida.Destino),
                    new("@Estado",          SqlDbType.VarChar,  salida.Estado),
                    new("@IdBarco",         SqlDbType.Int,      salida.IdBarco),
                    new("@IdCapitan",       SqlDbType.Int,      salida.IdCapitan)
                };
                return Consultas.EjecucionSinConsulta("SP_InsertarSalida", parametros) == 1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("No se pudo insertar el dato en la base de datos: " + ex.Message);
            }
        }

        public static bool FinalizarSalida(int idSalida, string estado)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdSalida", SqlDbType.Int,     idSalida),
                    new("@Estado",   SqlDbType.VarChar, estado)
                };
                return Consultas.EjecucionSinConsulta("SP_FinalizarSalida", parametros) != 0;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al finalizar el registro de salida: " + ex.Message);
            }
        }

        public static List<VOSalida> ConsultarSalidaPorEstado(string estado)
        {
            var lista = new List<VOSalida>();
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@Estado", SqlDbType.VarChar, estado)
                };
                DataTable resultados = Consultas.EjecucionConLlenado("SP_ConsultarSalidasPorEstado", parametros);
                foreach (DataRow registro in resultados.Rows)
                    lista.Add(new VOSalida(registro));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
            return lista;
        }

        public static List<VOSalidaExtendida> ConsultarSalidaPorEstadoExtendida(string estado)
        {
            var lista = new List<VOSalidaExtendida>();
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@Estado", SqlDbType.VarChar, estado)
                };
                DataTable resultados = Consultas.EjecucionConLlenado("SP_ConsultarSalidasPorEstadoExtendida", parametros);
                foreach (DataRow registro in resultados.Rows)
                    lista.Add(new VOSalidaExtendida(registro));
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
            return lista;
        }

        public static VOSalidaExtendida ConsultarSalidaPorIdExtendida(int idSalida)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdSalida", SqlDbType.Int, idSalida)
                };
                DataTable resultados = Consultas.EjecucionConLlenado("SP_ConsultarSalidasPorIdExtendida", parametros);
                return new VOSalidaExtendida(resultados.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
        }

        public static VOSalida ConsultarSalidaPorId(int idSalida)
        {
            try
            {
                var parametros = new List<Parametros>
                {
                    new("@IdSalida", SqlDbType.Int, idSalida)
                };
                DataTable resultados = Consultas.EjecucionConLlenado("SP_ConsultarSalidasPorId", parametros);
                return new VOSalida(resultados.Rows[0]);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al consultar el registro de salida: " + ex.Message);
            }
        }
    }
}
