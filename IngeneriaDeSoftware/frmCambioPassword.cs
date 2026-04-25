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
            BE_Usuario usuario = BLL_SessionManager.GetInstance.usuario;
            usuario.Password = BLL_Seguridad.Encriptar(txtPassword.Text);
            BLL_Usuario.CambiarPassword(usuario);
            this.Close();
        }
    }
}
