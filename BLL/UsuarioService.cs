using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        DAL.MapperUsuario mp = new DAL.MapperUsuario();

        public void IniciarSesion(BE.Usuario u)
        {
            mp.IniciarSesion(u);
        }

        public int Grabar(BE.Usuario u)
        {
            if (u.Id == 0)
            {
                Console.WriteLine($"Try register: usuario: {u.Username}, pass length: {u.Password}");
                return mp.Insertar(u);
            } else
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
