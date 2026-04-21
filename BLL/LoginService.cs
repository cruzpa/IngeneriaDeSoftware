using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace BLL
{
    public class LoginService
    {
        internal DAL.Login login = new DAL.Login();

        public bool IniciarSesion(BE.Usuario u)
        {
            BE.Usuario usuario = login.IniciarSesion(u.Username, u.Password);
            if (usuario != null)
            {
                Sesion.Instancia.Login(usuario);
                return true;
            }

            return false;
        }
    }
}
