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
        public void Crear(BE_Usuario usuario)
        {
            Acceso acceso = new Acceso();
            acceso.Abrir();
            acceso.Escribir($"insert into usuario (Usuario, Password) values ('{usuario.Usuario}', '{usuario.Password}')");
            acceso.Cerrar();
        }

        public void ReestablecerPassword(BE_Usuario usuario)
        {
            Acceso acceso = new Acceso();
            acceso.Abrir();
            acceso.Escribir($"update Usuario set Usuario.Password = '{usuario.Password}' where Usuario.Usuario = '{usuario.Usuario}'");
            acceso.Cerrar();
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
        public List<BE_Usuario> BuscarUsuarios(bool incluireliminados)
        {
            List<BE_Usuario> usuarios = new List<BE_Usuario>();
            Acceso acceso = new Acceso();
            acceso.Abrir();
            SqlDataReader reader = acceso.Leer($"select u.Usuario, u.Password from Usuario u");
            while (reader.Read())
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Usuario = reader["Usuario"].ToString();
                usuario.Password = reader["Password"].ToString();
                usuarios.Add(usuario);
            }
            acceso.Cerrar();
            return usuarios;
        }
    }
}
