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

        DAL_Usuario u = new DAL_Usuario();

        public void Crear (BE_Usuario usuario)
        {
            u.Crear(usuario);
        }

        public void CambiarPassword (BE_Usuario usuario)
        {
            u.CambiarPassword(usuario);
        }

        public BE_Usuario BuscarPorUsuario (string usuario)
        {
            return u.BuscarPorUsuario(usuario);
        }

        public List<BE_Usuario> BuscarUsuarios(bool incluireliminados)
        {
            return u.BuscarUsuarios(incluireliminados);
        }
        public void Modificar (BE_Usuario usuario)
        {
            u.Modificar(usuario);
        }
        public void IncrementarIntentosFallidos(BE_Usuario usuario)
        {
            u.IncrementarIntentosFallidos(usuario);
        }
        public void ReiniciarIntentosFallidos(BE_Usuario usuario)
        {
            u.ReiniciarIntentosFallidos(usuario);
        }
    }
}
