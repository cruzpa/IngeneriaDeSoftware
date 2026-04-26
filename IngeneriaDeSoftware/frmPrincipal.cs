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
    public partial class frmPrincipal : Form
    {
        Form form;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                msMenu.Visible = false;
                SessionManager.Logout();
                ssMenu.Visible = false;
                tsslUsuario.Text = "";
                AbrirFormulario<frmLogin>(form);

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
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            try
            {
                msMenu.Enabled = false;
                msMenu.Visible = false;
                ssMenu.Visible = false;
                tsslUsuario.Text = "";
                AbrirFormulario<frmLogin>(form);

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
        }

        private void AbrirFormulario<T>(Form f) where T : Form, new()
        {
            try
            {
                f = new T();
                if (typeof(T) == typeof(frmLogin)) f.FormClosed += Login;
                f.MdiParent = this;
                f.FormClosed += ResetForm;
                msMenu.Enabled = false;
                f.Show();
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
        }

        private void ResetForm(object p, EventArgs e)
        {
            try
            {
                form = null;
                msMenu.Enabled = true;
                ssMenu.Visible = true;
                SessionManager sesion = SessionManager.GetInstance;
                if (sesion != null)
                {
                    tsslUsuario.Text = sesion.usuario.Username;
                }
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
        }

        private void Login(object o, EventArgs e)
        {
            try
            {
                msMenu.Visible = true;
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
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormulario<frmUsuarios>(form);
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
        }

        private void bitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormulario<frmBitacora>(form);
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
        }
    }
}
