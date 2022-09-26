using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RiojasPrograma2
{



    internal static class CargarDatos
    {
        static SqlConnection cnx;
        static string cadena = "Server=localhost;Database=Faltas;Trusted_Connection=True;";

        private static void Conectar()
        {
            cnx = new SqlConnection(cadena);
            cnx.Open();

        }
        private static void Desconectar()
        {

            cnx.Close();
            cnx = null;

        }
        public static int EjecturaConsulta(string consulta)
        {
            int filasAfectadas = 0;
            Conectar();
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            filasAfectadas = cmd.ExecuteNonQuery();
            Desconectar();
            return filasAfectadas;
        }
        public static object EjecutarEscalar(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt.NewRow();


        }
        public static DataTable EjecutarSeleccion(string consulta)
        {
            DataTable dt = new DataTable();
            Conectar();
            SqlDataAdapter da = new SqlDataAdapter(consulta, cnx);
            da.Fill(dt);
            Desconectar();
            return dt;

        }
        

    }
}