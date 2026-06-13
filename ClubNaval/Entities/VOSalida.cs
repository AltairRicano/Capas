using System;
using System.Data;

namespace Entities
{
    public class VOSalida
    {
        public int IdSalida { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; }
        public int IdBarco { get; set; }
        public int IdCapitan { get; set; }

        public VOSalida() { }

        public VOSalida(DateTime fechaHoraSalida, string destino,
            string estado, int idBarco, int idCapitan)
        {
            FechaHoraSalida = fechaHoraSalida;
            Destino = destino;
            Estado = estado;
            IdBarco = idBarco;
            IdCapitan = idCapitan;
        }

        public VOSalida(DataRow dr)
        {
            IdSalida = int.Parse(dr["IdSalida"].ToString());
            FechaHoraSalida = DateTime.Parse(dr["FechaHoraSalida"].ToString());
            Destino = dr["Destino"].ToString();
            Estado = dr["Estado"].ToString();
            IdBarco = int.Parse(dr["IdBarco"].ToString());
            IdCapitan = int.Parse(dr["IdPersona"].ToString());
        }
    }
}