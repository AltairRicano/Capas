using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace BussinesLogic
{
    /// <summary>
    /// Lógica de negocio para la entidad Barco.
    /// Envuelve las operaciones del DAL con manejo de excepciones descriptivo.
    /// </summary>
    public class BLLBarco
    {
        public static async Task<bool> InsertarAsync(VOBarco barco)
        {
            try { return await DALBarco.InsertarAsync(barco); }
            catch (Exception ex) { throw new ArgumentException("Error al insertar barco: " + ex.Message); }
        }

        public static async Task<bool> ActualizarAsync(VOBarco barco)
        {
            try { return await DALBarco.ActualizarAsync(barco); }
            catch (Exception ex) { throw new ArgumentException("Error al actualizar barco: " + ex.Message); }
        }

        public static async Task<bool> EliminarAsync(int idBarco)
        {
            try { return await DALBarco.EliminarAsync(idBarco); }
            catch (Exception ex) { throw new ArgumentException("Error al eliminar barco: " + ex.Message); }
        }

        public static async Task<IEnumerable<VOBarco>> ConsultarTodosAsync(bool? disponibilidad = null)
        {
            try { return await DALBarco.ConsultarTodosAsync(disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar barcos: " + ex.Message); }
        }

        public static async Task<VOBarco> ConsultarPorIdAsync(int idBarco)
        {
            try { return await DALBarco.ConsultarPorIdAsync(idBarco); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar barco: " + ex.Message); }
        }
    }
}