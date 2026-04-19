using BE;
using System;
using System.Collections.Generic;
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
    }
}
