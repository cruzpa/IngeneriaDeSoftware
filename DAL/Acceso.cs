using System;
using System.Collections.Generic;
using System.Data;
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
            //conexion.ConnectionString = "Initial catalog=TP; Data Source=DESKTOP-JRRFOTR.;integrated security=SSPI";
            //conexion.ConnectionString = "Initial catalog=TP; Data Source=.;integrated security=SSPI";
            conexion.ConnectionString = "Initial catalog=TP; Data Source=DESKTOP-CLTJMFV\\SQLEXPRESS;integrated security=SSPI";
            conexion.Open();
        }
        public void Cerrar()
        {
            conexion.Close();
            conexion=null;
        }
        public void iniciarTx()
        {
            if (conexion.State == ConnectionState.Open)
            {
                tx = conexion.BeginTransaction();
            }
        }
        public void confirmarTx()
        {
            if (tx != null)
            {
                tx.Commit();
                tx = null;
            }
        }
        public void cancelarTx()
        {
            if (tx != null)
            {
                tx.Rollback();
                tx = null;
            }
        }
        public SqlCommand CrearComando(string sql, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion;
            cmd.CommandText = sql;
            cmd.CommandType = System.Data.CommandType.Text;
            
            if(parameters != null) cmd.Parameters.AddRange(parameters.ToArray());
            if (tx != null) cmd.Transaction = tx;
            return cmd;
        }
        public int Escribir(string sql, List<SqlParameter> parameters)
        {
            SqlCommand cmd = CrearComando(sql, parameters);
            int filas = 0;

            try
            {
                filas = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                filas = -1;
            }
            return filas;
        }
        public SqlDataReader Leer(string sql, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = CrearComando(sql, parameters);
            return cmd.ExecuteReader();
        }
        public int LeerEscalar(string sql, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = CrearComando(sql, parameters);
            return int.Parse(cmd.ExecuteScalar().ToString());
        }
        public SqlParameter CrearParametro(string name, string value)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.DbType = System.Data.DbType.String;
            return p;
        }
        public SqlParameter CrearParametro(string name, int value)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.DbType = System.Data.DbType.Int32;
            return p;
        }
        public SqlParameter CrearParametro(string name, float value)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.DbType = System.Data.DbType.Single;
            return p;
        }
        public SqlParameter CrearParametro(string name, DateTime value)
        {
            SqlParameter p = new SqlParameter(name, value);
            p.DbType = System.Data.DbType.DateTime;
            return p;
        }
    }
}