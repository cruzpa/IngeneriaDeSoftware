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

        private void ClaveModificada(object o, EventArgs e) 
        {
            this.Visible = true;
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            int resultado = LoginService.Login(txtUsuario.Text, txtPassword.Text);
            switch (resultado)
            {
                case 1:
                    this.Close();
                    break;
                case 2:
                    MessageBox.Show("Usuario inexistente");
                    break;
                case 3:
                    MessageBox.Show("Password incorrecto");
                    break;
                case 4:
                    MessageBox.Show("Usuario bloqueado");
                    break;
                case 5:
                    MessageBox.Show("Usuario eliminado");
                    break;
                case 6:
                    MessageBox.Show("Cambio de password requerido");
                    frmCambioPassword f = new frmCambioPassword();
                    f.FormClosed += ClaveModificada;
                    this.Visible = false;
                    f.Show();
                    break;
                default:
                    MessageBox.Show("Error");
                    break;
            }
        }
    }
}
