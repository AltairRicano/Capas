using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades
{
    public class VOBarco
    {
        private int idBarco;
        private string matricula;
        private string noAmarre;
        private string nombre;
        private double? cuota;
        private int? idPersona;
        private string urlFoto;
        private bool? disponibilidad;

        public VOBarco(int idBarco, string matricula, string noAmarre, string nombre, double? cuota,
            int? idPersona, string urlFoto, bool? disponibilidad)
        {
            this.idBarco = idBarco;
            this.matricula = matricula;
            this.noAmarre = noAmarre;
            this.nombre = nombre;
            this.cuota = cuota;
            this.idPersona = idPersona;
            this.urlFoto = urlFoto;
            this.disponibilidad = disponibilidad;
        }

        public VOBarco(string matricula, string noAmarre, string nombre, double? cuota,
            int? idPersona, string urlFoto, bool? disponibilidad)
        {
            this.matricula = matricula;
            this.noAmarre = noAmarre;
            this.nombre = nombre;
            this.cuota = cuota;
            this.idPersona = idPersona;
            this.urlFoto = urlFoto;
            this.disponibilidad = disponibilidad;
        }

        public VOBarco(DataRow fila)
        {
            this.idBarco = int.Parse(fila["IdBarco"].ToString());
            this.matricula = fila["Matricula"].ToString();
            this.noAmarre = fila["NoAmarre"].ToString();
            this.nombre = fila["Nombre"].ToString();
            this.cuota = double.Parse(fila["Cuota"].ToString());
            this.idPersona = int.Parse(fila["IdOwner"].ToString());
            this.urlFoto = fila["UrlFoto"].ToString();
            this.disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
        }

        public VOBarco(List<object> datos)
        {
            this.idBarco = int.Parse(datos[0].ToString());
            this.matricula = datos[1].ToString();
            this.noAmarre = datos[2].ToString();
            this.nombre = datos[3].ToString();
            this.cuota = double.Parse(datos[4].ToString());
            this.idPersona = int.Parse(datos[5].ToString());
            this.disponibilidad = bool.Parse(datos[6].ToString());
            this.urlFoto = datos[7].ToString();
        }

        public int IdBarco { get => idBarco; set => idBarco = value; }
        public string Matricula { get => matricula; set => matricula = value; }
        public string NoAmarre { get => noAmarre; set => noAmarre = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double? Cuota { get => cuota; set => cuota = value; }
        public int? IdPersona { get => idPersona; set => idPersona = value; }
        public string UrlFoto { get => urlFoto; set => urlFoto = value; }
        public bool? Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
    }
}
