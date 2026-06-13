using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccess;
using Entities;

namespace BussinesLogic
{
    /// <summary>
    /// Lógica de negocio para la entidad Persona.
    /// Envuelve las operaciones del DAL con manejo de excepciones descriptivo.
    /// </summary>
    public class BLLPersona
    {
        public static async Task InsertarAsync(VOPersona persona)
        {
            try { await DALPersona.InsertarAsync(persona); }
            catch (Exception ex) { throw new ArgumentException("Error al insertar persona: " + ex.Message); }
        }

        public static async Task ActualizarAsync(VOPersona persona)
        {
            try { await DALPersona.ActualizarAsync(persona); }
            catch (Exception ex) { throw new ArgumentException("Error al actualizar persona: " + ex.Message); }
        }

        public static async Task EliminarAsync(int idPersona)
        {
            try { await DALPersona.EliminarAsync(idPersona); }
            catch (Exception ex) { throw new ArgumentException("Error al eliminar persona: " + ex.Message); }
        }

        public static async Task<VOPersona> ConsultarPorIdAsync(int idPersona)
        {
            try { return await DALPersona.ConsultarPorIdAsync(idPersona); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar persona: " + ex.Message); }
        }

        public static async Task<IEnumerable<VOPersona>> ConsultarTodasAsync(bool? disponibilidad = null)
        {
            try { return await DALPersona.ConsultarTodasAsync(disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar personas: " + ex.Message); }
        }

        public static async Task<IEnumerable<VOPersona>> ConsultarPorCargoAsync(int cargo, bool? disponibilidad = null)
        {
            try { return await DALPersona.ConsultarPorCargoAsync(cargo, disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar por cargo: " + ex.Message); }
        }
    }
}