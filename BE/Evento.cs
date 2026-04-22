using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Evento
    {
        public long Id { get; set; }
        public DateTimeOffset FechaHora { get; set; }
        public string UsuarioId { get; set; }
        public NivelCriticidad Criticidad { get; set; }
        public string Mensaje { get; set; }
        public string Modulo { get; set; }        // Ej: "Login", "Pagos"
        public string Accion { get; set; }        // Ej: "Crear", "Actualizar", "Eliminar"
        public string Entidad { get; set; }       // Ej: "Usuario", "Pedido"
        public string EntidadId { get; set; }

    }

    public enum NivelCriticidad
    {
        Baja,
        Media,
        Alta,
        Critica
    }

    public Evento(string usuarioId = null,
                    NivelCriticidad criticidad = NivelCriticidad.Baja, 
                    string mensaje = null,
                    string modulo = null,
                    string accion = null,
                    string entidad = null,
                    string entidadId = null)
    {
        FechaHora = DateTimeOffset.UtcNow;
        UsuarioId = usuarioId;
        Criticidad = criticidad;
        Mensaje = mensaje;
        Modulo = modulo;
        Accion = accion;
        Entidad = entidad;
        EntidadId = entidadId;
    }
}
