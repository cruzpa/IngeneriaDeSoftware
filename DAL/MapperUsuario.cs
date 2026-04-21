using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MapperUsuario : Mapper<Usuario>
    {
        public override int Insertar(Usuario u)
        {
            acceso = new Acceso();
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@nombre", u.Name));
            parametros.Add(acceso.CrearParametro("@username", u.Username));
            parametros.Add(acceso.CrearParametro("@password", u.Password));
            string query = "INSERT INTO Usuario (Id, Nombre, Username, Password)\r\nSELECT ISNULL(MAX(Id), 0) + 1, @nombre, @username, @password\r\nFROM Usuario\r\nWHERE NOT EXISTS (\r\n    SELECT 1 \r\n    FROM Usuario \r\n    WHERE Username = @username\r\n);";
            int res = acceso.Escribir(query, parametros);
            acceso.Cerrar();
            return res;
        }
        public override int Editar(Usuario u)
        {
            acceso = new Acceso();
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", u.Id));
            parametros.Add(acceso.CrearParametro("@nombre", u.Name));
            parametros.Add(acceso.CrearParametro("@username", u.Username));
            parametros.Add(acceso.CrearParametro("@password", u.Password));
            string query = "IF NOT EXISTS (\r\n    SELECT 1 FROM Usuario \r\n    WHERE Username = @username AND Id <> @id\r\n)\r\nBEGIN\r\n    UPDATE Usuario\r\n    SET Nombre = @nombre,\r\n        Username = @username,\r\n        Password = @password\r\n    WHERE Id = @id\r\nEND";
            int res = acceso.Escribir(query, parametros);
            acceso.Cerrar();
            return res;
        }
        public override int Borrar(Usuario u) 
        {
            acceso = new Acceso();
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", u.Id));
            int res = acceso.Escribir("DELETE FROM Usuario\r\nWHERE Id = @id", parametros);
            acceso.Cerrar();
            return res;

        }
        public override List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            acceso = new Acceso();
            acceso.Abrir();

            SqlDataReader reader = acceso.Leer("SELECT Id, Nombre, Username, Password FROM Usuario");
            while (reader.Read())
            {
                Usuario u = new Usuario();
                u.Id  = reader.GetInt32(0);
                u.Name = reader.GetString(1);
                u.Username = reader.GetString(2);
                usuarios.Add(u);
            }
            reader.Close();
            reader = null;

            acceso.Cerrar();
            return usuarios;
        }

        public void IniciarSesion(Usuario u)
        {
            throw new NotImplementedException();
        }
    }
}
