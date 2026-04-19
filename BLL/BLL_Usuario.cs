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
        public void Crear (BE_Usuario usuario)
        {
            DAL_Usuario u = new DAL_Usuario();
            u.Crear (usuario);
        }

        public void CambiarPassword (BE_Usuario usuario)
        {
            DAL_Usuario u = new DAL_Usuario();
            u.CambiarPassword(usuario);
        }

        public BE_Usuario BuscarPorUsuario (string usuario)
        {
            DAL_Usuario u = new DAL_Usuario();
            return u.BuscarPorUsuario(usuario);
        }

        public List<BE_Usuario> BuscarUsuarios(bool incluireliminados)
        {
            DAL_Usuario u = new DAL_Usuario();
            return u.BuscarUsuarios(incluireliminados);
        }
    }
}
