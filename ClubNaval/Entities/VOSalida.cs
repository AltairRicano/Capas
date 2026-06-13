using System;


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


    }
}