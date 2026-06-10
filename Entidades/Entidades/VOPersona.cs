using System;
using System.Collections.Generic;
using System.Data;

namespace Entidades
{
    public class VOPersona
    {
        private int idPersona;
        private string telefono;
        private string direccion;
        private string nombre;
        private string correo;
        private int? cargo;
        private bool? disponibilidad;
        private string urlFoto;

        public VOPersona(int idPersona, string telefono, string direccion, string nombre,
            string correo, int? cargo, bool? disponibilidad, string urlFoto)
        {
            this.IdPersona = idPersona;
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Cargo = cargo;
            this.Disponibilidad = disponibilidad;
            this.UrlFoto = urlFoto;
        }

        public VOPersona(string telefono, string direccion, string nombre, string correo,
            int? cargo, bool? disponibilidad, string urlFoto)
        {
            this.Telefono = telefono;
            this.Direccion = direccion;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Cargo = cargo;
            this.Disponibilidad = disponibilidad;
            this.UrlFoto = urlFoto;
        }

        public VOPersona(DataRow fila)
        {
            IdPersona = int.Parse(fila["IdPersona"].ToString());
            Nombre = fila["Nombre"].ToString();
            Direccion = fila["Direccion"].ToString();
            Telefono = fila["Telefono"].ToString();
            Correo = fila["Correo"].ToString();
            Cargo = int.Parse(fila["Cargo"].ToString());
            UrlFoto = fila["UrlFoto"].ToString();
            Disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
        }

        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public int? Cargo { get => cargo; set => cargo = value; }
        public bool? Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public string UrlFoto { get => urlFoto; set => urlFoto = value; }
    }
}
