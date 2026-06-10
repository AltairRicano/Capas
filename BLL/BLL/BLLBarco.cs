using System;
using System.Collections.Generic;
using DAL;
using Entidades;

namespace BLL
{
    public class BLLBarco
    {
        public static bool Insertar(VOBarco barco)
        {
            try { return DALBarco.Insertar(barco); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static bool Actualizar(VOBarco barco)
        {
            try { return DALBarco.Actualizar(barco); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static bool Eliminar(string idBarco)
        {
            try { return DALBarco.Eliminar(int.Parse(idBarco)); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static VOBarco ConsultarBarco(string idBarco)
        {
            try
            {
                var barco = DALBarco.ConsultarBarco(int.Parse(idBarco));
                if (barco == null)
                    throw new ArgumentException("El id buscado no existe en la base de datos");
                return barco;
            }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static List<VOBarco> ConsultarBarcos(bool? disponibilidad)
        {
            try { return DALBarco.ConsultarBarcos(disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Ocurrió un error. " + ex.Message); }
        }

        public static List<VOBarco> ConsultarBarcosPorOwner(string idOwner, bool? disponibilidad)
        {
            try { return DALBarco.ConsultarBarcosPorOwner(int.Parse(idOwner), disponibilidad); }
            catch (Exception ex) { throw new ArgumentException("Ocurrio un error. " + ex.Message); }
        }
    }
}
