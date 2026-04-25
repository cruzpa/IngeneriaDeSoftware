using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Bitacora
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public DateTime FechaYHora { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
        public BE_Bitacora() { }
        public BE_Bitacora(string usuario, DateTime fechayHora, string tipo, string descripcion) : base()
        {
            Usuario = usuario;
            FechaYHora = fechayHora;
            Tipo = tipo;
            Descripcion = descripcion;
        }
    }
}
