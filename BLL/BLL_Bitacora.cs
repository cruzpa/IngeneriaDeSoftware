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
        public void Crear(BE_Bitacora bitacora)
        {
            DAL_Bitacora b = new DAL_Bitacora();
            b.Crear(bitacora);
        }
        public List<BE_Bitacora> Buscar()
        {
            List<BE_Bitacora> lista = new List<BE_Bitacora>();




            return lista;
        }
    }
}
