using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Login
    {
        public BE.Usuario IniciarSesion(string username, string password)
        {
            BE.Usuario usuario = null;
            Acceso acceso = new Acceso();
            acceso.Abrir();
            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@username", username));
            parametros.Add(acceso.CrearParametro("@password", password));
            string query = "SELECT * FROM usuario WHERE Username = @username AND Password = @password";
            
            SqlDataReader reader = acceso.Leer(query, parametros);
            if (reader.Read())
            {
                usuario = new BE.Usuario();
                usuario.Id = Convert.ToInt32(reader["Id"]);
                usuario.Name = reader["Name"].ToString();
                usuario.Username = reader["Username"].ToString();
                usuario.Password = reader["Password"].ToString();
            }
            acceso.Cerrar();
            return usuario;
        }
    }
}
