using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class BLLSalida
    {
        public static bool InsertarSalida(VOSalida salida)
        {
            try
            {
                // Marcar barco como no disponible al iniciar la salida
                var barco = new VOBarco(salida.IdBarco, null, null, null, null, null, null, false);
                BLLBarco.Actualizar(barco);
                return DALSalida.InsertarSalida(salida);
            }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static bool FinalizarSalida(string idSalida)
        {
            try
            {
                return DALSalida.FinalizarSalida(int.Parse(idSalida),
                    Enum.GetName(typeof(EstadoSalida), EstadoSalida.FINALIZADA));
            }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static List<VOSalida> ConsultarSalidaPorEstado(string estado)
        {
            try { return DALSalida.ConsultarSalidaPorEstado(estado); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static List<VOSalidaExtendida> ConsultarSalidaPorEstadoExtendida(string estado)
        {
            try { return DALSalida.ConsultarSalidaPorEstadoExtendida(estado); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static VOSalida ConsultarSalidaPorId(string idSalida)
        {
            try { return DALSalida.ConsultarSalidaPorId(int.Parse(idSalida)); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static VOSalidaExtendida ConsultarSalidaPorIdExtendida(string idSalida)
        {
            try { return DALSalida.ConsultarSalidaPorIdExtendida(int.Parse(idSalida)); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public enum EstadoSalida
        {
            EN_PROCESO,
            FINALIZADA
        }
    }
}
