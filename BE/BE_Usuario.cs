using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario
    {
        //agregar id
        public string Usuario { get; set; } //cambiar a username
        public string Password { get; set; }
        public bool Eliminado { get; set; }
        public int IntentosFallidos { get; set; }
        public bool Bloqueado { get; set; }
        //agregar info personal, name (nombre de usuario), apellido, email, telefono, etc.

    }
}
