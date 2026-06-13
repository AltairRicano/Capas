using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace DataAccess
{
    /// <summary>
    /// Provee la cadena de conexión leyéndola desde appsettings.json.
    /// </summary>
    public class Conexion
    {
        public string CadenaConexion { get; private set; }

        public Conexion()
        {
            try
            {
                // Busca appsettings.json en el directorio de la DLL de DataAccess
                string rutaBase = AppDomain.CurrentDomain.BaseDirectory;
                string rutaJson = Path.Combine(rutaBase, "appsettings.json");

                if (!File.Exists(rutaJson))
                    throw new FileNotFoundException("No se encontró appsettings.json en: " + rutaBase);

                string json = File.ReadAllText(rutaJson);
                JObject config = JObject.Parse(json);
                CadenaConexion = config["ConnectionStrings"]["BDMarinaConnectionString"].ToString();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error al configurar la cadena de conexión: " + ex.Message);
            }
        }
    }
}