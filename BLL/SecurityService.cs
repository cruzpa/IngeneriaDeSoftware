using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL
{
    public static class SecurityService
    {
        public static List<string> ValidarPassword(string password)
        {
            var errores = new List<string>();

            if (string.IsNullOrWhiteSpace(password))
            {
                errores.Add("El password no puede estar vacío.");
                return errores;
            }

            if (password.Length < 8)
                errores.Add("Debe tener al menos 8 caracteres.");

            if (!Regex.IsMatch(password, @"[A-Za-z]"))
                errores.Add("Debe contener al menos una letra.");

            if (!Regex.IsMatch(password, @"\d"))
                errores.Add("Debe contener al menos un número.");

            if (!Regex.IsMatch(password, @"^[A-Za-z\d]+$"))
                errores.Add("Solo se permiten caracteres alfanuméricos.");

            Console.WriteLine(string.Join(", ", errores));
            return errores;
        }

        public static string Encriptar(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);

                return Convert.ToBase64String(hash);
            }
        }

        public static bool VerificarPassword(string passwordPlano, string passwordHash)
        {
            string hashCalculado = Encriptar(passwordPlano);
            return hashCalculado == passwordHash;
        }
    }
}