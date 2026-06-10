using System;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class Conexion
    {
        private string cadenaConexion;

        public Conexion()
        {
            Configurar();
        }

        public string CadenaConexion => cadenaConexion;

        public void Configurar()
        {
            try
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();
                cadenaConexion = config["CADENA_CONEXION"]
                    ?? throw new ArgumentException("No se encontró la clave 'CADENA_CONEXION' en appsettings.json");
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al configurar la cadena de conexión: " + ex.Message);
            }
        }
    }
}
