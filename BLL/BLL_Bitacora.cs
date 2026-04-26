using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Bitacora
    {
        DAL_Bitacora b = new DAL_Bitacora();

        public int Crear(BE_Bitacora bitacora)
        {
            int filas = b.Crear(bitacora);
            if (filas < 0)
            {
                Console.WriteLine("Error al crear la bitacora");
            }
            return filas;
        }
        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio)
        {
            return b.Buscar(tipo, fechaInicio);
        }
        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio, string fechafin)
        {
            return b.Buscar(tipo, fechaInicio, fechafin);
        }
    }
}
