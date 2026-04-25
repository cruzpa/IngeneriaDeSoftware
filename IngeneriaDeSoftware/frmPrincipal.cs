using BE;
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
    public partial class frmPrincipal : Form
    {
        Form form;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            msMenu.Visible = false;
            SessionManager.Logout();
            ssMenu.Visible = false;
            tsslUsuario.Text = "";
            AbrirFormulario<frmLogin>(form);
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            msMenu.Enabled = false;
            msMenu.Visible = false;
            ssMenu.Visible = false;
            tsslUsuario.Text = "";
            AbrirFormulario<frmLogin>(form);
        }

        private void AbrirFormulario<T>(Form f) where T : Form, new()
        {
            f = new T();
            if (typeof(T) == typeof(frmLogin)) f.FormClosed += Login;
            f.MdiParent = this;
            f.FormClosed += ResetForm;
            msMenu.Enabled = false;
            f.Show();
        }

        private void ResetForm(object p, EventArgs e)
        {
            form = null;
            msMenu.Enabled = true;
            ssMenu.Visible = true;
            SessionManager sesion = SessionManager.GetInstance;
            if (sesion != null)
            {
                tsslUsuario.Text = sesion.usuario.User;
            }
        }

        private void Login(object o, EventArgs e)
        {
            msMenu.Visible = true;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmUsuarios>(form);
        }

        private void bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario<frmBitacora>(form);
        }
    }
}
