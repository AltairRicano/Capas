using System;


namespace Entities
{
    public class VOBarco
    {
        public int IdBarco { get; set; }
        public string Matricula { get; set; }
        public string NoAmarre { get; set; }
        public string Nombre { get; set; }
        public double? Cuota { get; set; }
        public int? IdPersona { get; set; }
        public string UrlFoto { get; set; }
        public bool? Disponibilidad { get; set; }
        public bool? Activo { get; set; }

        public VOBarco() { }

        public VOBarco(int idBarco, string matricula, string noAmarre, string nombre,
            double? cuota, int? idPersona, string urlFoto, bool? disponibilidad)
        {
            IdBarco = idBarco;
            Matricula = matricula;
            NoAmarre = noAmarre;
            Nombre = nombre;
            Cuota = cuota;
            IdPersona = idPersona;
            UrlFoto = urlFoto;
            Disponibilidad = disponibilidad;
        }

        public VOBarco(string matricula, string noAmarre, string nombre,
            double? cuota, int? idPersona, string urlFoto, bool? disponibilidad)
        {
            Matricula = matricula;
            NoAmarre = noAmarre;
            Nombre = nombre;
            Cuota = cuota;
            IdPersona = idPersona;
            UrlFoto = urlFoto;
            Disponibilidad = disponibilidad;
        }


    }
}