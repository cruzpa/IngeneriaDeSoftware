using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Servicios
{
    public class BLL_SessionManager
    {
        private static BLL_SessionManager _session;
        private static object _lock = new object();
        public BE_Usuario usuario { get; set; }

        public static BLL_SessionManager GetInstance
        {
            get 
            {
                return _session;
            }
        }

        public static void Login(BE_Usuario usuario)
        {
            lock (_lock) 
            {
                if (_session == null)
                {
                    _session = new BLL_SessionManager();
                    _session.usuario = usuario;
                }
                else
                {
                    throw new Exception("Ya hay una sesión iniciada");
                }
            }
        }

        public static void Logout()
        {
            lock (_lock)
            {
                if (_session != null)
                {
                    _session = null;
                }
                else
                {
                    throw new Exception("Sesión no iniciada");
                }
            }
        }

        private BLL_SessionManager() 
        {

        }
    }
}
