using BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Bitacora
    {
        private readonly Acceso acceso = new Acceso();
        public int Crear(BE_Bitacora bitacora)
        {
            int resultado = 0;
            if (bitacora == null) return resultado;
            acceso.Abrir();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@Usuario", bitacora.Usuario),
                    acceso.CrearParametro("@FechaYHora", bitacora.FechaYHora.ToString()),
                    acceso.CrearParametro("@Tipo", bitacora.Tipo),
                    acceso.CrearParametro("@Descripcion", bitacora.Descripcion)
                };
                resultado = acceso.Escribir($"insert into Bitacora (Usuario, FechaYHora, Tipo, Descripcion) values (@Usuario, @FechaYHora, @Tipo, @Descripcion)", parametros);
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return resultado;
        }
        public List<BE_Bitacora> Buscar(string fechaInicio, string fechaFin)
        {
            acceso.Abrir();
            List<BE_Bitacora> lista = new List<BE_Bitacora>();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@FechaInicio", fechaInicio),
                    acceso.CrearParametro("@FechaFin", fechaFin)
                };

                SqlDataReader reader = acceso.Leer("select Id, Usuario, FechaYHora, Tipo, Descripcion from Bitacora where FechaYHora >= @FechaInicio and FechaYHora <= @FechaFin", parametros);
                while (reader.Read())
                {
                    BE_Bitacora bitacora = new BE_Bitacora();
                    bitacora.Id = int.Parse(reader["Id"].ToString());
                    bitacora.Usuario = reader["Username"].ToString();
                    bitacora.FechaYHora = DateTime.Parse(reader["Password"].ToString());
                    bitacora.Tipo = reader["Nombre"].ToString();
                    bitacora.Descripcion = reader["Apellido"].ToString();
                    lista.Add(bitacora);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return lista;
        }
        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio, string fechaFin)
        {
            acceso.Abrir();
            List<BE_Bitacora> lista = new List<BE_Bitacora>();
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    acceso.CrearParametro("@FechaInicio", fechaInicio),
                    acceso.CrearParametro("@FechaFin", fechaFin)
                };
                SqlDataReader reader = acceso.Leer("select Id, Usuario, FechaYHora, Tipo, Descripcion from Bitacora where FechaYHora >= @FechaInicio and FechaYHora <= @FechaFin and Tipo = @Tipo", parametros);
                while (reader.Read())
                {
                    BE_Bitacora bitacora = new BE_Bitacora();
                    bitacora.Id = int.Parse(reader["Id"].ToString());
                    bitacora.Usuario = reader["Username"].ToString();
                    bitacora.FechaYHora = DateTime.Parse(reader["Password"].ToString());
                    bitacora.Tipo = reader["Nombre"].ToString();
                    bitacora.Descripcion = reader["Apellido"].ToString();
                    lista.Add(bitacora);
                }
            }
            catch (Exception ex) { throw ex; }
            finally { acceso.Cerrar(); }
            return lista;
        }
    }
}
