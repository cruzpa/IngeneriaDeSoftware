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
        // DAL_Bitacora b = new DAL_Bitacora();
        //sacar de los metodos
        public void Crear(BE_Bitacora bitacora)
        {
            DAL_Bitacora b = new DAL_Bitacora();
            b.Crear(bitacora);
        }
        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio)
        {
            List<BE_Bitacora> lista = new List<BE_Bitacora>();
            DAL_Bitacora b = new DAL_Bitacora();
            return b.Buscar(tipo, fechaInicio);
        }
        public List<BE_Bitacora> Buscar(string tipo, string fechaInicio, string fechafin)
        {
            List<BE_Bitacora> lista = new List<BE_Bitacora>();
            DAL_Bitacora b = new DAL_Bitacora();
            return b.Buscar(tipo, fechaInicio, fechafin);
        }
    }
}
