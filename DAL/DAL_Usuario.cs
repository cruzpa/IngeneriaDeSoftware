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
            acceso.Escribir($"insert into usuario (Usuario, Password, Eliminado, IntentosFallidos, Bloqueado) values ('{usuario.Usuario}', '{usuario.Password}', '{usuario.Eliminado}', 0, 0)");
            acceso.Cerrar();
        }

        public void CambiarPassword(BE_Usuario usuario)
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
            SqlDataReader reader = acceso.Leer($"select u.Usuario, u.Password, u.Eliminado, u.IntentosFallidos, u.Bloqueado from Usuario u where u.Usuario = '{user}' and u.Eliminado = 0");
            while (reader.Read())
            {
                usuario.Usuario = reader["Usuario"].ToString();
                usuario.Password = reader["Password"].ToString();
                usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
            }
            acceso.Cerrar();
            return usuario;
        }
        public List<BE_Usuario> BuscarUsuarios(bool incluireliminados)
        {
            List<BE_Usuario> usuarios = new List<BE_Usuario>();
            Acceso acceso = new Acceso();
            acceso.Abrir();
            if (incluireliminados)
            {
                SqlDataReader reader = acceso.Leer($"select u.Usuario, u.Password, u.Eliminado, u.IntentosFallidos, u.Bloqueado from Usuario u");
                while (reader.Read())
                {
                    BE_Usuario usuario = new BE_Usuario();
                    usuario.Usuario = reader["Usuario"].ToString();
                    usuario.Password = reader["Password"].ToString();
                    usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                    usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                    usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
                    usuarios.Add(usuario);
                }
            }
            else
            {
                SqlDataReader reader = acceso.Leer($"select u.Usuario, u.Password, u.Eliminado from Usuario u where u.Eliminado = 0");
                while (reader.Read())
                {
                    BE_Usuario usuario = new BE_Usuario();
                    usuario.Usuario = reader["Usuario"].ToString();
                    usuario.Password = reader["Password"].ToString();
                    usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                    usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                    usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
                    usuarios.Add(usuario);
                }
            }
            acceso.Cerrar();
            return usuarios;
        }
        public void Modificar(BE_Usuario usuario)
        {
            Acceso acceso = new Acceso();
            acceso.Abrir();
            if (usuario.Eliminado && usuario.Bloqueado) acceso.Escribir($"update Usuario set Usuario.Eliminado = 1, Usuario.Bloqueado = 1 where Usuario.Usuario = '{usuario.Usuario}'");
            else if (usuario.Eliminado && !usuario.Bloqueado) acceso.Escribir($"update Usuario set Usuario.Eliminado = 1, Usuario.Bloqueado = 0 where Usuario.Usuario = '{usuario.Usuario}'");
            else if (!usuario.Eliminado && usuario.Bloqueado) acceso.Escribir($"update Usuario set Usuario.Eliminado = 0, Usuario.Bloqueado = 1 where Usuario.Usuario = '{usuario.Usuario}'");
            else if (!usuario.Eliminado && !usuario.Bloqueado) acceso.Escribir($"update Usuario set Usuario.Eliminado = 0, Usuario.Bloqueado = 0 where Usuario.Usuario = '{usuario.Usuario}'");
            acceso.Cerrar();
        }

        public void IncrementarIntentosFallidos(BE_Usuario usuario)
        {
            if (usuario.IntentosFallidos > 4)
            {
                usuario.Bloqueado = true;
                Modificar(usuario);
            }
            else
            {
                usuario.IntentosFallidos++;
                Acceso acceso = new Acceso();
                acceso.Abrir();
                acceso.Escribir($"update Usuario set Usuario.IntentosFallidos = {usuario.IntentosFallidos} where Usuario.Usuario = '{usuario.Usuario}'");
                acceso.Cerrar();
            }
        }

        public void ReiniciarIntentosFallidos(BE_Usuario usuario)
        {
            Acceso acceso= new Acceso();
            acceso.Abrir();
            acceso.Escribir($"update Usuario set Usuario.IntentosFallidos = {usuario.IntentosFallidos} where Usuario.Usuario = '{usuario.Usuario}'");
            acceso.Cerrar();
        }
    }
}
