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
                    acceso.CrearParametro("@Username", usuario.Username),
                    acceso.CrearParametro("@Password", usuario.Password),
                    acceso.CrearParametro("@Nombre", usuario.Nombre),
                    acceso.CrearParametro("@Apellido", usuario.Apellido),
                    acceso.CrearParametro("@Email", usuario.Email),
                    acceso.CrearParametro("@Telefono", usuario.Telefono)
                };
                resultado = acceso.Escribir($"insert into Usuario (Username, Password, Nombre, Apellido, Email, Telefono, IntentosFallidos, Bloqueado, Eliminado) values (@Username, @Password, @Nombre, @Apellido, @Email, @Telefono, 0,0,0)", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-CREAR USUARIO - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.Password = @Password where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-CAMBIAR PASSWORD - " + ex.Message); }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public BE_Usuario BuscarPorUsername(string username)
        {
            if (username == string.Empty) return null;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Username", username)
                };
                SqlDataReader reader = acceso.Leer("select Usuario.Id, Usuario.Username, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario where Usuario.Username = @Username", parametros);
                if (reader.Read())
                {
                    BE_Usuario usuario = new BE_Usuario();
                    {
                        usuario.Id = int.Parse(reader["Id"].ToString());
                        usuario.Username = reader["Username"].ToString();
                        usuario.Password = reader["Password"].ToString();
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.Apellido = reader["Apellido"].ToString();
                        usuario.Email = reader["Email"].ToString();
                        usuario.Telefono = reader["Telefono"].ToString();
                        usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                        usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
                        usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                    };
                    return usuario;
                }
                return null;
            }
            catch (Exception ex) { throw new Exception("DAL-BUSCAR USUARIO POR USERNAME - " + ex.Message); }
            finally { acceso.Cerrar(); }
        }
        public BE_Usuario BuscarPorId(int id)
        {
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", id)
                };
                SqlDataReader reader = acceso.Leer("select Usuario.Id, Usuario.Username, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario where Usuario.Id = @Id", parametros);
                if (reader.Read())
                {
                    BE_Usuario usuario = new BE_Usuario();
                    {
                        usuario.Id = int.Parse(reader["Id"].ToString());
                        usuario.Username = reader["Username"].ToString();
                        usuario.Password = reader["Password"].ToString();
                        usuario.Nombre = reader["Nombre"].ToString();
                        usuario.Apellido = reader["Apellido"].ToString();
                        usuario.Email = reader["Email"].ToString();
                        usuario.Telefono = reader["Telefono"].ToString();
                        usuario.IntentosFallidos = int.Parse(reader["IntentosFallidos"].ToString());
                        usuario.Bloqueado = bool.Parse(reader["Bloqueado"].ToString());
                        usuario.Eliminado = bool.Parse(reader["Eliminado"].ToString());
                    }
                    ;
                    return usuario;
                }
                return null;
            }
            catch (Exception ex) { throw new Exception("DAL-BUSCAR USUARIO POR ID - " + ex.Message); }
            finally { acceso.Cerrar(); }
        }
        public List<BE_Usuario> BuscarUsuarios(bool incluirEliminados)
        {
            acceso.Abrir();
            List<BE_Usuario> usuarios = new List<BE_Usuario>();
            try
            {
                SqlDataReader reader;
                if (incluirEliminados) reader = acceso.Leer("select Usuario.Id, Usuario.Username, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario");
                else reader = acceso.Leer("select Usuario.Id, Usuario.Username, Usuario.Password, Usuario.Nombre, Usuario.Apellido, Usuario.Email, Usuario.Telefono, Usuario.IntentosFallidos, Usuario.BLoqueado, Usuario.Eliminado from Usuario where Usuario.Eliminado = 'false'");
                while (reader.Read())
                {
                    BE_Usuario usuario = new BE_Usuario();
                    usuario.Id = int.Parse(reader["Id"].ToString());
                    usuario.Username = reader["Username"].ToString();
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
            catch (Exception ex) { throw new Exception("DAL-BUSCAR USUARIOS - " + ex.Message); }
            finally { acceso.Cerrar(); }
            return usuarios;
        }
        public int ModificarUsername(BE_Usuario usuario)
        {
            int resultado = 0;
            if (usuario == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Id", usuario.Id),
                    acceso.CrearParametro("@Username", usuario.Username)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Username = @User where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-MODIFICAR USERNAME - " + ex.Message); }
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
                    acceso.CrearParametro("@Nombre", usuario.Nombre),
                    acceso.CrearParametro("@Apellido", usuario.Apellido),
                    acceso.CrearParametro("@Email", usuario.Email),
                    acceso.CrearParametro("@Telefono", usuario.Telefono)
                };
                resultado = acceso.Escribir($"update Usuario set Usuario.Nombre = @Nombre, Usuario.Apellido = @Apellido, Usuario.Email = @Email, Usuario.Telefono = @Telefono where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-MODIFICAR USUARIO - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.IntentosFallidos = @IntentosFallidos where Usuario.Id= @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-INCREMENTAR INTENTOS FALLIDOS - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.IntentosFallidos = 0 where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-REINICIAR INTENTOS FALLIDOS - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.Bloqueado = 'true' where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-BLOQUEAR USUARIO - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.Bloqueado = 'false' where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-DESBLOQUEAR USUARIO - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.Eliminado = 'true' where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-ELIMINAR USUARIO - " + ex.Message); }
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
                resultado = acceso.Escribir($"update Usuario set Usuario.Eliminado = 'false' where Usuario.Id = @Id", parametros);
            }
            catch (Exception ex) { throw new Exception("DAL-HABILITAR USUARIO - " + ex.Message); }
            finally { acceso.Cerrar(); }
            return resultado;
        }
    }
}
