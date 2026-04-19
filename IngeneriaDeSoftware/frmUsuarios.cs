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
    public partial class frmUsuarios : Form
    {
        List<BE_Usuario> usuarios;
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            CargarListaUsuarios(true);
            ActualizarGrillaUsuarios();
        }

        private void CargarListaUsuarios(bool incluirEliminados) 
        {
            BLL_Usuario u = new BLL_Usuario();
            usuarios = u.BuscarUsuarios(incluirEliminados);
            u = null;
        }
        private void ActualizarGrillaUsuarios()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Password");
            if (usuarios == null) return;
            foreach (BE_Usuario u in usuarios)
            {
                DataRow dr = dt.NewRow();
                dr[0] = u.Usuario;
                dr[1] = u.Password;
                dt.Rows.Add(dr);
            }
            dgvUsuarios.DataSource = dt;
        }

        private void dgvUsuarios_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0) 
                {
                    txtUsuario.Text = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema con la grilla");
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                BLL_Usuario usuario = new BLL_Usuario();
                BE_Usuario u = new BE_Usuario();
                u.Usuario = txtUsuario.Text;
                u.Password = Seguridad.Encriptar("cambiar");
                usuario.Crear(u);
                CargarListaUsuarios(true);
                ActualizarGrillaUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema durante la creación del usuario");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema durante el borrado del usuario");
            }
        }

        private void btnReestablecerPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvUsuarios.SelectedRows.Count > 0)
                {
                    BE_Usuario usuario = new BE_Usuario();
                    BLL_Usuario u = new BLL_Usuario();
                    usuario.Usuario = dgvUsuarios.SelectedRows[0].Cells[0].Value.ToString();
                    usuario.Password = Seguridad.Encriptar("cambiar");
                    u.ReestablecerPassword(usuario);

                    CargarListaUsuarios(true);
                    ActualizarGrillaUsuarios();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un problema al intentar reestablecer la contraseña");
            }

        }
    }
}
