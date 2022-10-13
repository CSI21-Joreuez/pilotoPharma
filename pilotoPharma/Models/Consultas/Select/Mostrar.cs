using Npgsql;

namespace pilotoPharma.Models.Consultas.Select
{
    public class Mostrar
    {
        public static NpgsqlCommand MuestraDatos(string tabla, NpgsqlConnection conexion)
        {
            NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"dlk_operacional_productos\".\"" + tabla + "\"", conexion);
            return consulta;                
        }
    }
}
