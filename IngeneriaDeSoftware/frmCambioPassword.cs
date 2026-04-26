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
            BLL_Usuario u = new BLL_Usuario();
            BE_Usuario usuario = SessionManager.GetInstance.usuario;
            usuario.Password = SecurityService.Encriptar(txtPassword.Text);
            u.CambiarPassword(usuario);
            this.Close();
        }
    }
}
