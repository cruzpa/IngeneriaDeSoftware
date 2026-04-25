using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_Bitacora
    {
        private readonly static DAL_Bitacora b = new DAL_Bitacora();
        public static void Crear(BE_Bitacora bitacora)
        {
            b.Crear(bitacora);
        }
        public static List<BE_Bitacora> Buscar(string tipo, string fechaInicio)
        {
            return b.Buscar(tipo, fechaInicio);
        }
        public static List<BE_Bitacora> Buscar(string tipo, string fechaInicio, string fechafin)
        {
            return b.Buscar(tipo, fechaInicio, fechafin);
        }
    }
}
