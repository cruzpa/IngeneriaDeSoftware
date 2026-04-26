using BE;
using BLL;
using Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class frmCambioPassword : Form
    {
        public frmCambioPassword()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = SessionManager.GetInstance.usuario;
                usuario.Password = SeguridadService.Encriptar(txtPassword.Text);
                UsuarioService.CambiarPassword(usuario);
            }
            catch (Exception ex)
            {
                try
                {
                    BE_Bitacora bitacora = new BE_Bitacora(SessionManager.GetInstance.usuario.Username, DateTime.UtcNow, "CRITICAL", ex.Message);
                    BitacoraService.Crear(bitacora);
                    MessageBox.Show("Error crítico, contacte al administrador.");
                }
                catch { throw new Exception("HAY QUE HACER EL LOG DE BITACORA LOCAL EN TXT"); }
            }
            finally { this.Close(); }
        }
    }
}
