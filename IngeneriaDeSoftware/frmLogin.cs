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
            BLL_Usuario u = new BLL_Usuario();

            //aca crear un LoginService como esta en mi branch y que haga toda las validaciones de login y retorne resultado booleano para menssage.Box
            BE_Usuario usuario = u.BuscarPorUsuario(txtUsuario.Text);
            BE_Bitacora bitacora = new BE_Bitacora();
            BLL_Bitacora b = new BLL_Bitacora();

            if (usuario.Bloqueado == true) 
            {
                MessageBox.Show("El usuario se encuentra bloqueado");
                
                bitacora.Username = "Sin usuario";
                bitacora.FechaYHora = DateTimeOffset.Now;
                bitacora.Tipo = "WARNING";
                bitacora.Descripcion = $"Intento de ingreso con el usuario \"{txtUsuario.Text}\" que se encuentra bloqueado";

                b.Crear(bitacora);

                return;
            }

            if (usuario.Username != txtUsuario.Text)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
                
                bitacora.Username = "Sin usuario";
                bitacora.FechaYHora = DateTimeOffset.Now;
                bitacora.Tipo = "WARNING";
                bitacora.Descripcion = $"Intento fallido de ingreso con usuario inexistente: \"{txtUsuario.Text}\"";

                b.Crear(bitacora);

                return;
            }

            if (usuario.Password != SecurityService.Encriptar(txtPassword.Text))
            {
                MessageBox.Show("Usuario o contraseña incorrectos");

                u.IncrementarIntentosFallidos(usuario);

                bitacora.Username = "Sin usuario";
                bitacora.FechaYHora = DateTimeOffset.Now;
                bitacora.Tipo = "WARNING";
                bitacora.Descripcion = $"Intento fallido de ingreso con el usuario \"{txtUsuario.Text}\"";

                b.Crear(bitacora);

                return;
            }

            SessionManager.Login(usuario);
            bitacora.Username = SessionManager.GetInstance.usuario.Username;
            bitacora.FechaYHora = DateTimeOffset.Now;
            bitacora.Tipo = "INFO";
            bitacora.Descripcion = $"Ingreso al sistema";

            b.Crear(bitacora);

            if (txtPassword.Text == "cambiar")
            {
                frmCambioPassword f = new frmCambioPassword();
                f.FormClosed += ClaveModificada;
                this.Visible = false;
                f.Show();
                return;
            }

            if (usuario.IntentosFallidos != 0)
            {
                usuario.IntentosFallidos = 0;
                u.ReiniciarIntentosFallidos(usuario);
            }

            this.Close();
        }
    }
}
