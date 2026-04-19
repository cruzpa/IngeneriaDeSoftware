using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Usuario
    {
        public int Crear (BE_Usuario usuario)
        {
            return 0;
        }

        public BE_Usuario BuscarPorUsuario (string usuario)
        {
            DAL_Usuario u = new DAL_Usuario ();
            return u.BuscarPorUsuario(usuario);
        }
    }
}
