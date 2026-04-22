using BE;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class UsuarioService
    {
        DAL.MapperUsuario mp = new DAL.MapperUsuario();
        private SecurityService security = new SecurityService();

        public int Grabar(BE.Usuario u)
        {
            if (security.ValidarPassword(u.Password).Any())
            {
                //throw new Exception("Password inválido. Debe tener al menos 8 caracteres alfanuméricos.");
                //throw new Exception("Password inválido. Debe tener al menos 8 caracteres alfanuméricos.");
                return 0;
            }
            u.Password = security.HashPassword(u.Password);

            if (u.Id == 0)
            {
                Console.WriteLine($"Try register: usuario: {u.Username}, pass length: {u.Password}");
                return mp.Insertar(u);
            }
            else
            {
                return mp.Editar(u);
            }
        }

        public int Borrar(BE.Usuario u)
        {
            return mp.Borrar(u);
        }

        public List<Usuario> Listar()
        {
            return mp.Listar();
        }
    }
}