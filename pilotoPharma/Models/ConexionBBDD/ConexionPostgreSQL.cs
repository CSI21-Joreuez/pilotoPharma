﻿using Npgsql;

namespace pilotoPharma.Models.ConexionBBDD
{
    /* ConexionPostgreSQL - Clase que realiza la conexión a PostgreSQL de forma parametrizada; basándose en la información 
    * de conexión recogida en el fichero util.VariablesConexionPostgreSQL.cs
    * @author Joreuez
    * 13/10/2022
    */
    public class ConexionPostgreSQL
    {
        //MÉTODOS
        public NpgsqlConnection GeneraConexion(string host, string port,
            string db, string user, string pass)
        {
            System.Console.WriteLine("[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Entra en GeneraConexion");
            
            //Se crea una nueva conexión y la cadena con los datos de conexión.
            NpgsqlConnection conexion = new NpgsqlConnection();
            var datosConexion = "Server="+host+"; Port="+port+"; User Id="+user+"; Password="+pass+"; Database=" +db;
            //var datosConexion = "Server=localhost; Port=5432; User Id=postgres; Password=pr0f3s0r; Database=EjemploInicial";
            System.Console.WriteLine(datosConexion);
            var estado = "";
            if (!string.IsNullOrWhiteSpace(datosConexion))
            {
                try
                {
                    conexion = new NpgsqlConnection(datosConexion);
                    conexion.Open();
                    //Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    System.Console.WriteLine("[INFORMACIÓN-GeneraPostgreSQL-GeneraConexion] Estado conexión: "+estado);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine("[ERROR-conexionPostgresql-generaConexion] Error al crear conexión:" + e);
                    conexion.Close();
                }
            }

            return conexion;

        }
        public static void CloseConection(NpgsqlConnection conexion)
        {
            conexion.Close();
        }
    }
}
