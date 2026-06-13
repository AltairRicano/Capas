using System;


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
        public bool? Activo { get; set; }

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


    }
}