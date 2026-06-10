using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class BLLPersona
    {
        public static void Insertar(VOPersona persona)
        {
            try { DALPersona.Insertar(persona); }
            catch { throw new ArgumentException("No se pudo insertar el dato"); }
        }

        public static void Eliminar(string idPersona)
        {
            try { DALPersona.EliminarPersona(int.Parse(idPersona)); }
            catch { throw new ArgumentException("No se pudo eliminar el dato"); }
        }

        public static void Actualizar(VOPersona persona)
        {
            try { DALPersona.Actualizar(persona); }
            catch { throw new ArgumentException("No se pudo actualizar el dato"); }
        }

        public static List<VOPersona> ConsultarPersonasPorCargo(string cargo, bool? disponibilidad)
        {
            try { return DALPersona.ConsultarPersonasPorCargo(int.Parse(cargo), disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar el registro de persona: " + ex.Message); }
        }

        public static VOPersona ConsultarPersonaPorId(string idPersona)
        {
            try { return DALPersona.ConsultarPersonaPorId(int.Parse(idPersona)); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar el registro de persona: " + ex.Message); }
        }

        public static List<VOPersona> CatalogoPersona(int[] cargo, bool? disp)
        {
            var catalogo = new List<VOPersona>();
            foreach (int c in cargo)
                catalogo.AddRange(ConsultarPersonasPorCargo(c.ToString(), disp));
            return catalogo;
        }

        public static List<VOPersona> ConsultarPersonas(bool? disponibilidad)
        {
            try { return DALPersona.ConsultarPersonas(disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Error al consultar el registro de persona: " + ex.Message); }
        }
    }
}
