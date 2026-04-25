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
        private readonly Acceso acceso = new Acceso();
        public int Crear(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@User", usuario.User),
                    acceso.CrearParametro("@Password", usuario.Password),
                    acceso.CrearParametro("@Nombre", usuario.Nombre),
                    acceso.CrearParametro("@Apellido", usuario.Apellido),
                    acceso.CrearParametro("@Email", usuario.Email),
                    acceso.CrearParametro("@Telefono", usuario.Telefono)
                };
                resultado = acceso.Escribir($"insert into Usuario (User, Password, Nombre, Apellido, Email, Telefono, IntentosFaillidos, Bloqueado, Eliminado) values (@User, @Password, @Nombre, @Apellido, @Email, @Telefono, 0,0,0)", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }

        public int CambiarPassword(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id),
                    acceso.CrearParametro("@Password", usuario.Password)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Password = @Password where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public BE_Usuario BuscarPorUsuario(string user)
        {
            if (user == string.Empty) return null;
            acceso.Abrir();
            BE_Usuario usuario = new BE_Usuario();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@User", user)
                };
                SqlDataReader reader = acceso.Leer("select Usuario.Id, Usuario.User, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario where Usuario.User = @User", parametros);
                while (reader.Read())
                {
                    usuario.Id = int.Parse(reader["Id"].ToString());
                    usuario.User = reader["Username"].ToString();
                    usuario.Password = reader["Password"].ToString();
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Apellido = reader["Apellido"].ToString();
                    usuario.Email = reader["Email"].ToString();
                    usuario.Telefono = reader["Telefono"].ToString();
                    usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                    usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
                    usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                }
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return usuario;
        }
        public List<BE_Usuario> BuscarUsuarios(bool incluireliminados)
        {
            acceso.Abrir();
            List<BE_Usuario> usuarios = new List<BE_Usuario>();
            try
            {
                SqlDataReader reader;
                if (incluireliminados) reader = acceso.Leer("select Usuario.Id, Usuario.User, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario");
                else reader = acceso.Leer("select Usuario.Id, Usuario.User, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario where Usuario.Eliminado = 'false'");
                while (reader.Read())
                {
                    BE_Usuario usuario = new BE_Usuario();
                    usuario.Id = int.Parse(reader["Id"].ToString());
                    usuario.User = reader["Username"].ToString();
                    usuario.Password = reader["Password"].ToString();
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Apellido = reader["Apellido"].ToString();
                    usuario.Email = reader["Email"].ToString();
                    usuario.Telefono = reader["Telefono"].ToString();
                    usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                    usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
                    usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                    usuarios.Add(usuario);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return usuarios;
        }
        public int ModificarUser(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id),
                    acceso.CrearParametro("@User", usuario.User)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.User = @User where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public int Modificar(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id),
                    acceso.CrearParametro("@Nombre", usuario.Id),
                    acceso.CrearParametro("@Apellido", usuario.Id),
                    acceso.CrearParametro("@Email", usuario.Id),
                    acceso.CrearParametro("@Telefono", usuario.Id)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Nombre = @Nombre, Usuario.Apellido = @Apellido, Usuario.Email = @Email, Usuario.Telefono = @Telefono where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }

        public int IncrementarIntentosFallidos(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id),
                    acceso.CrearParametro("@IntentosFallidos", usuario.IntentosFallidos)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.IntentosFallidos = @IntentosFallidos where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }

        public int ReiniciarIntentosFallidos(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.IntentosFallidos = 0 where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public int Bloquear(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Bloqueado = ture where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public int Desbloquear(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Bloqueado = false where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public int Eliminar(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Eliminado = true where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public int Habilitar(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Eliminado = false where Usuario.Usuario = @Id", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
    }
}
