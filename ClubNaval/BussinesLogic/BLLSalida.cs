using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace BussinesLogic
{
    /// <summary>
    /// Lógica de negocio para la entidad Salida.
    /// Envuelve las operaciones del DAL con manejo de excepciones descriptivo.
    /// </summary>
    public class BLLSalida
    {
        public static async Task<bool> InsertarAsync(VOSalida salida)
        {
            try { return await DALSalida.InsertarAsync(salida); }
            catch (Exception ex) { throw new ArgumentException("Error al insertar salida: " + ex.Message); }
        }

        public static async Task<bool> FinalizarAsync(int idSalida)
        {
            try { return await DALSalida.FinalizarAsync(idSalida, "Terminada"); }
            catch (Exception ex) { throw new ArgumentException("Error al finalizar salida: " + ex.Message); }
        }

        public static async Task<bool> EliminarAsync(int idSalida)
        {
            try { return await DALSalida.EliminarAsync(idSalida); }
            catch (Exception ex) { throw new ArgumentException("Error al eliminar salida: " + ex.Message); }
        }

        public static async Task<IEnumerable<VOSalidaExtendida>> ConsultarPorEstadoAsync(string estado = null)
        {
            try { return await DALSalida.ConsultarPorEstadoAsync(estado); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar salidas: " + ex.Message); }
        }

        public static async Task<VOSalidaExtendida> ConsultarPorIdAsync(int idSalida)
        {
            try { return await DALSalida.ConsultarPorIdAsync(idSalida); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar salida: " + ex.Message); }
        }
    }
}