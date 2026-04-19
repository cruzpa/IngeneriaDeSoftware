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
    public partial class Principal : Form
    {
        Form form;
        public Principal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            msMenu.Enabled = false;
            msMenu.Visible = false;
            AbrirFormulario<frmLogin>(form);
        }

        private void AbrirFormulario<T>(Form f) where T : Form, new()
        {
            f = new T();
            if (typeof(T) == typeof(frmLogin)) f.FormClosed += Login;
            f.MdiParent = this;
            f.FormClosed += ResetForm;
            f.Show();
        }

        private void ResetForm(object p, EventArgs e)
        {
            form = null;
            msMenu.Enabled = true;
        }

        private void Login(object o, EventArgs e)
        {
            msMenu.Visible = true;
        }
    }
}
