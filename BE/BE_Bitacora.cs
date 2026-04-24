using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    // usar DateTimeOffset
    public class BE_Bitacora
    {
        public int Id { get; set; }
        public string Usuario { get; set; } //username
        public string FechaYHora { get; set; }
        public string Tipo { get; set; }
        public string Descripcion { get; set; }
    }
}
