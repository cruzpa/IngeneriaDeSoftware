using System;
using System.Data.SqlClient;

namespace DAL
{
    internal class Acceso
    {
        private SqlConnection conexion;
        private SqlTransaction tx;

        public void Abrir()
        {
            conexion = new SqlConnection();
            conexion.ConnectionString = "Initial catalog=TP; Data Source=DESKTOP-JRRFOTR.;integrated security=SSPI";
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
            conexion=null;
            GC.Collect();   
        }

        //agregar qparams para evitar injeccion sql
        public SqlCommand CrearComando(string sql)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Connection = conexion;
            return cmd;
        }

        public int Escribir(String sql)
        {
            SqlCommand cmd = CrearComando(sql);
            int filas = 0; //cantidad de filas afectadas

            try
            {
                filas = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                filas = -1;
            }
            return filas;
        }
        public SqlDataReader Leer(String sql)
        {
            SqlCommand cmd = CrearComando(sql);
            return cmd.ExecuteReader();
        }

        public int LeerEscalar(String sql)
        {
            SqlCommand cmd = CrearComando(sql);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }

    }
}