using System;
using System.Linq;

namespace BLL
{
    public class LoginService
    {
        internal DAL.Login login = new DAL.Login();
        private SecurityService security = new SecurityService();

        public bool IniciarSesion(BE.Usuario u)
        {
            if (security.ValidarPassword(u.Password).Any())
            {
                return false;
            }
            string passwordHash = security.HashPassword(u.Password);
            BE.Usuario usuario = login.IniciarSesion(u.Username, passwordHash);

            if (usuario != null)
            {
                Sesion.Instancia.Login(usuario);
                return true;
            }

            return false;
        }
    }
}