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
        public void Grabar(BE.Usuario u)
        {
            if (u.Id == 0)
            {
                mp.Insertar(u);
            } else
            {
                mp.Editar(u);
            }
        }

        public void Borrar(BE.Usuario u)
        {
            mp.Borrar(u);

        }

        public void Listar()
        {
            mp.Listar();  
        }


    }
}
