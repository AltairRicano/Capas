using System;
using System.Data;

namespace Entities
{
    public class VOSalidaExtendida : VOSalida
    {
        public string NombreCapitan { get; set; }
        public string UrlFotoCapitan { get; set; }
        public string NombreBarco { get; set; }
        public string UrlFotoBarco { get; set; }

        public VOSalidaExtendida() : base()
        {
            NombreCapitan = "";
            UrlFotoCapitan = "";
            NombreBarco = "";
            UrlFotoBarco = "";
        }

        public VOSalidaExtendida(DataRow dr) : base(dr)
        {
            NombreCapitan = dr["NombreCapitan"].ToString();
            UrlFotoCapitan = dr["UrlFotoCapitan"].ToString();
            NombreBarco = dr["NombreBarco"].ToString();
            UrlFotoBarco = dr["UrlFotoBarco"].ToString();
        }
    }
}