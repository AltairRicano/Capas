using System;
using System.Data;

namespace Entities
{
    public class VOPersona
    {
        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public int? Cargo { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

        public VOPersona() { }

        public VOPersona(int idPersona, string nombre, string telefono,
            string direccion, string correo, int? cargo, bool? disponibilidad, string urlFoto)
        {
            IdPersona = idPersona;
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;
            Correo = correo;
            Cargo = cargo;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
        }

        public VOPersona(string nombre, string telefono, string direccion,
            string correo, int? cargo, bool? disponibilidad, string urlFoto)
        {
            Nombre = nombre;
            Telefono = telefono;
            Direccion = direccion;
            Correo = correo;
            Cargo = cargo;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
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
    }
}