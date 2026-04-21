using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public sealed class Sesion
    {
        private static Sesion _instancia;
        private static readonly object _lock = new object();

        public static Sesion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    lock (_lock)
                    {
                        if (_instancia == null)
                        {
                            _instancia = new Sesion();
                        }
                    }
                }
                return _instancia;
            }
        }

        private Sesion() { }

        public BE.Usuario UsuarioActual { get; private set; }

        public void Login(BE.Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}
