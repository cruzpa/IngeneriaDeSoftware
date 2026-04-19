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
        public void Crear(BE_Bitacora bitacora)
        {
            Acceso acceso = new Acceso();
            acceso.Abrir();
            acceso.Escribir($"insert into Bitacora (Usuario, FechaYHora, Tipo, Descripcion) values ('{bitacora.Usuario}', '{bitacora.FechaYHora}', '{bitacora.Tipo}', '{bitacora.Descripcion}')");
            acceso.Cerrar();
        }

        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio)
        {
            List<BE_Bitacora> lista = new List<BE_Bitacora>();
            Acceso acceso = new Acceso();
            acceso.Abrir();

            if (tipo == "TODOS") 
            {
                SqlDataReader reader = acceso.Leer($"select b.Id, b.Usuario, b.FechaYHora, b.Tipo, b.Descripcion from Bitacora b where b.FechaYHora >= '{fechaInicio}'");
                while (reader.Read())
                {
                    BE_Bitacora bitacora = new BE_Bitacora();
                    bitacora.Id = int.Parse(reader["Id"].ToString());
                    bitacora.Usuario = reader["Usuario"].ToString();
                    bitacora.FechaYHora = reader["FechaYHora"].ToString();
                    bitacora.Tipo = reader["Tipo"].ToString();
                    bitacora.Descripcion = reader["Descripcion"].ToString();
                    lista.Add(bitacora);
                }
            }
            else
            {
                SqlDataReader reader = acceso.Leer($"select b.Id, b.Usuario, b.FechaYHora, b.Tipo, b.Descripcion from Bitacora b where b.tipo = '{tipo}' and b.FechaYHora >= '{fechaInicio}'");
                while (reader.Read())
                {
                    BE_Bitacora bitacora = new BE_Bitacora();
                    bitacora.Id = int.Parse(reader["Id"].ToString());
                    bitacora.Usuario = reader["Usuario"].ToString();
                    bitacora.FechaYHora = reader["FechaYHora"].ToString();
                    bitacora.Tipo = reader["Tipo"].ToString();
                    bitacora.Descripcion = reader["Descripcion"].ToString();
                    lista.Add(bitacora);
                }
            }

            acceso.Cerrar();
            return lista;
        }
        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio, string fechaFin)
        {
            List<BE_Bitacora> lista = new List<BE_Bitacora>();
            Acceso acceso = new Acceso();
            acceso.Abrir();
            if (tipo == "TODOS")
            {
                SqlDataReader reader = acceso.Leer($"select b.Id, b.Usuario, b.FechaYHora, b.Tipo, b.Descripcion from Bitacora b where b.FechaYHora >= '{fechaInicio}' and b.FechaYHora <= '{fechaFin}'");
                while (reader.Read())
                {
                    BE_Bitacora bitacora = new BE_Bitacora();
                    bitacora.Id = int.Parse(reader["Id"].ToString());
                    bitacora.Usuario = reader["Usuario"].ToString();
                    bitacora.FechaYHora = reader["FechaYHora"].ToString();
                    bitacora.Tipo = reader["Tipo"].ToString();
                    bitacora.Descripcion = reader["Descripcion"].ToString();
                    lista.Add(bitacora);
                }
            }
            else
            {
                SqlDataReader reader = acceso.Leer($"select b.Id, b.Usuario, b.FechaYHora, b.Tipo, b.Descripcion from Bitacora b where b.tipo = '{tipo}' and b.FechaYHora >= '{fechaInicio}' and b.FechaYHora <= '{fechaFin}'");
                while (reader.Read())
                {
                    BE_Bitacora bitacora = new BE_Bitacora();
                    bitacora.Id = int.Parse(reader["Id"].ToString());
                    bitacora.Usuario = reader["Usuario"].ToString();
                    bitacora.FechaYHora = reader["FechaYHora"].ToString();
                    bitacora.Tipo = reader["Tipo"].ToString();
                    bitacora.Descripcion = reader["Descripcion"].ToString();
                    lista.Add(bitacora);
                }
            }
            acceso.Cerrar();
            return lista;
        }
    }
}
