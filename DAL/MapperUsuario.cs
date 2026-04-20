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
            int res = acceso.Escribir("sql..", parametros);
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
            int res = acceso.Escribir("sql..", parametros);
            acceso.Cerrar();
            return res;
        }
        public override int Borrar(Usuario u) 
        {
            acceso = new Acceso();
            acceso.Abrir();

            List<SqlParameter> parametros = new List<SqlParameter>();
            parametros.Add(acceso.CrearParametro("@id", u.Id));
            int res = acceso.Escribir("sql..", parametros);
            acceso.Cerrar();
            return res;

        }
        public override List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            acceso = new Acceso();
            acceso.Abrir();

            //completar

            acceso.Cerrar();
            return usuarios;
        }

        public void IniciarSesion(Usuario u)
        {
            throw new NotImplementedException();
        }
    }
}
