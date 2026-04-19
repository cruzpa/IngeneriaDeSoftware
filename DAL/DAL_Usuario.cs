using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    public class DAL_Usuario
    {
        public int Crear(BE_Usuario usuario)
        {
            return 0;
        }
        public BE_Usuario BuscarPorUsuario(string user)
        {
            BE_Usuario usuario = new BE_Usuario();
            Acceso acceso = new Acceso();
            acceso.Abrir();
            SqlDataReader reader = acceso.Leer($"select u.Usuario, u.Password from Usuario u where u.Usuario = '{user}'");
            while (reader.Read())
            {
                usuario.Usuario = reader["Usuario"].ToString();
                usuario.Password = reader["Password"].ToString();
            }
            acceso.Cerrar();
            return usuario;
        }
    }
}
