using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoginService
    {
        internal DAL.Login login = new DAL.Login();

        public void IniciarSesion(BE.Usuario u)
        {
            login.IniciarSesion(u.Username, u.Password);
        }
    }
}
