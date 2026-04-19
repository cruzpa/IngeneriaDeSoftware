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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            BLL_Usuario u = new BLL_Usuario();
            BE_Usuario usuario = u.BuscarPorUsuario(txtUsuario.Text);
            if (usuario.Usuario != txtUsuario.Text || usuario.Password != Seguridad.Encriptar(txtPassword.Text))
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                return;
            }
            this.Close();
        }
    }
}
