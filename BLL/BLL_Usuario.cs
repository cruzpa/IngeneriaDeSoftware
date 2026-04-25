using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class BLL_Usuario
    {
        private readonly static DAL_Usuario u = new DAL_Usuario();
        public static void Crear (BE_Usuario usuario)
        {
            u.Crear(usuario);
        }

        public static void CambiarPassword (BE_Usuario usuario)
        {
            u.CambiarPassword(usuario);
        }

        public static BE_Usuario BuscarPorUsuario (string usuario)
        {
            return u.BuscarPorUsuario(usuario);
        }

        public static List<BE_Usuario> BuscarUsuarios(bool incluireliminados)
        {
            return u.BuscarUsuarios(incluireliminados);
        }
        public static void Modificar (BE_Usuario usuario)
        {
            u.Modificar(usuario);
        }
        public static void IncrementarIntentosFallidos(BE_Usuario usuario)
        {
            u.IncrementarIntentosFallidos(usuario);
        }
        public static void ReiniciarIntentosFallidos(BE_Usuario usuario)
        {
            u.ReiniciarIntentosFallidos(usuario);
        }
        public static int Bloquear(BE_Usuario usuario)
        {
            int resultado = u.Bloquear(usuario);
            return resultado;
        }
        public static bool ValidarBloqueado(BE_Usuario usuario)
        {
            if (usuario == null) return false;
            if (usuario.Bloqueado) return false;
            return true;
        }
        public static bool ValidarEliminado(BE_Usuario usuario)
        {
            if (usuario == null) return false;
            if (!usuario.Eliminado) return false;
            return true;
        }
    }
}
