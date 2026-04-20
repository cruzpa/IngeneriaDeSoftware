using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IngeneriaDeSoftware
{
    public partial class FormLogin : Form
    {
        BE.Usuario usuario;
        BLL.LoginService loginService = new BLL.LoginService();

        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario = new BE.Usuario();
            usuario.Username = textBox1.Text;
            usuario.Password = textBox2.Text;
            loginService.IniciarSesion(usuario);

            usuario = null;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
