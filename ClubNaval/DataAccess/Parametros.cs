using System.Data;

namespace DataAccess
{
    public struct Parametros
    {
        public string Nombre { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }

        public Parametros(string nombre, SqlDbType tipo, object valor)
        {
            Nombre = nombre;
            Tipo = tipo;
            Valor = valor;
        }
    }
}