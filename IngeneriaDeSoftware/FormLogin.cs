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
        BLL.UsuarioService usuarioService = new BLL.UsuarioService();

        public FormLogin()
        {
            InitializeComponent();
            button2.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuario = new BE.Usuario();
            usuario.Username = textBox1.Text;
            usuario.Password = textBox2.Text;
            Console.WriteLine($"Try login: usuario: {usuario.Username}, pass length: {usuario.Password}");
            bool ok = loginService.IniciarSesion(usuario);
            if (!ok)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos",
                    "Error de login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            usuario = null;
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usuario = new BE.Usuario();
            usuario.Username = textBox1.Text;
            usuario.Password = textBox2.Text;
            Console.WriteLine($"Try register: usuario: {usuario.Username}, pass length: {usuario.Password}");

            int res = usuarioService.Grabar(usuario);
            if (res == 1)
            {
                MessageBox.Show(
                    "Registrado con exito",
                    "Registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }else
            {
                MessageBox.Show(
                    "Error al registrar",
                    "Registro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
