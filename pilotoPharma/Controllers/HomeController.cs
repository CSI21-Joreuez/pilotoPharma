using Microsoft.AspNetCore.Mvc;
using pilotoPharma.Models.ConexionBBDD;
using pilotoPharma.Models.DTOs;
using pilotoPharma.Models;
using System.Diagnostics;
using pilotoPharma.Util;
using pilotoPharma.Models.Consultas;
using pilotoPharma.Models.Consultas.Select;
using Npgsql;
using System.Collections.Generic;

namespace pilotoPharma.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(ConexionPostgreSQL conexionPostgreSQL)
        {
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

            //CONSTANTES
            const string HOST = VariablesConexionPostgreSQL.HOST;
            const string PORT = VariablesConexionPostgreSQL.PORT;
            const string USER = VariablesConexionPostgreSQL.USER;
            const string PASS = VariablesConexionPostgreSQL.PASS;
            const string DB = VariablesConexionPostgreSQL.DB;

            //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
            var estadoGenerada = "";
            NpgsqlConnection conexionGenerada = new NpgsqlConnection();
            conexionGenerada = conexionPostgreSQL.GeneraConexion(HOST, PORT, DB, USER, PASS);
            estadoGenerada = conexionGenerada.State.ToString();
            System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

            //Se define la consulta a realizar y se guarda el resultado
            try
            {
                NpgsqlCommand consulta = new NpgsqlCommand("INSERT INTO dlk_operacional_productos.opr_cat_productos (md_uuid, cod_producto, nombre_producto, tipo_producto_origen, tipo_producto_clase, des_producto) VALUES ('adf131029022fch12345', 'hig_p_gelf_f', 'Gel de aceite de fresa, Farlane', 'Propio', 'Higiene', 'Gel de aceite de fresa producido por marca propia Farlane')", conexionGenerada);
                NpgsqlCommand consultaProductos = Mostrar.MuestraDatos("opr_cat_productos", conexionGenerada);
                NpgsqlDataReader insercionProductos = consulta.ExecuteReader();
                insercionProductos.Close();
                NpgsqlDataReader resultadoConsultaProductos = consultaProductos.ExecuteReader();
                while (resultadoConsultaProductos.Read())
                {
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\t{5} \n",
                    resultadoConsultaProductos[0], resultadoConsultaProductos[1], resultadoConsultaProductos[2], resultadoConsultaProductos[3], resultadoConsultaProductos[4], resultadoConsultaProductos[5]);
                }
                resultadoConsultaProductos.Close();
            }
            catch (Exception e)
            {

                System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
                ConexionPostgreSQL.CloseConection(conexionGenerada);

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}