using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public static class BLL_Seguridad
    {
        public static string Encriptar(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }
        public static bool ValidarPassword(string username, string password)
        {
            BE_Usuario usuario = BLL_Usuario.BuscarPorUsuario(username);
            if (usuario.Password == BLL_Seguridad.Encriptar(password)) return true;
            return false;
        }
    }
}
