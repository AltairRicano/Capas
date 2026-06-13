using System;


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


    }
}