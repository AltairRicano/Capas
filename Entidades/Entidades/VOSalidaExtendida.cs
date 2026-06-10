using System.Data;

namespace Entidades
{
    public class VOSalidaExtendida : VOSalida
    {
        private string nombreCapitan;
        private string urlFotoCapitan;
        private string nombreBarco;
        private string urlFotoBarco;

        public VOSalidaExtendida(string nombreCapitan, string urlFotoCapitan, string nombreBarco, string urlFotoBarco)
        {
            NombreCapitan = nombreCapitan;
            UrlFotoCapitan = urlFotoCapitan;
            NombreBarco = nombreBarco;
            UrlFotoBarco = urlFotoBarco;
        }

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

        public string NombreCapitan { get => nombreCapitan; set => nombreCapitan = value; }
        public string UrlFotoCapitan { get => urlFotoCapitan; set => urlFotoCapitan = value; }
        public string NombreBarco { get => nombreBarco; set => nombreBarco = value; }
        public string UrlFotoBarco { get => urlFotoBarco; set => urlFotoBarco = value; }
    }
}
